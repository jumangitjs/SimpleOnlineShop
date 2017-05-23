using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using AspNet.Security.OpenIdConnect.Primitives;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Core;
using Serilog;
using Serilog.Sinks.PostgreSQL;
using SimpleOnlineShop.SimpleOnlineShop.Application;
using SimpleOnlineShop.SimpleOnlineShop.Application.Web;
using SimpleOnlineShop.SimpleOnlineShop.Domain.AuthEntitiesAgg;
using SimpleOnlineShop.SimpleOnlineShop.Domain.InventoryAgg;
using SimpleOnlineShop.SimpleOnlineShop.Domain.UserAgg;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.Extension;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure.Events;

namespace SimpleOnlineShop.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            var connectionString = Configuration.GetConnectionString("SimpleOnlineShop");
            var logsTable = Configuration["LogsTable"];
            
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.PostgreSqlServer(connectionString, logsTable)
                .WriteTo.LiterateConsole()
                .CreateLogger();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) 
        {
            // Add framework services.
            services.AddDbContext<UnitOfWork>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("SimpleOnlineShop"));
            });

            //repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IInventoryProductRepository, InventoryProductRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            //web app services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IInventoryService, InventoryService>();
            
            InitializePolicies(services);

            services.AddMvc();
        }

        private void InitializePolicies(IServiceCollection services)
        {
            var scopeFactory = services
                .BuildServiceProvider()
                .GetRequiredService<IServiceScopeFactory>();

            services.AddAuthorization(options =>
            {
                using (var scope = scopeFactory.CreateScope())
                {
                    var provider = scope.ServiceProvider;
                    using (var dbContext = provider.GetRequiredService<UnitOfWork>())
                    {
                        var permissions = dbContext.Permissions
                            .Include("Roles.Role")
                            .AsEnumerable();    

                        foreach (var permission in permissions)
                        {
                            options.AddPolicy(permission.Name, policy =>
                            {
                                policy.RequireClaim(OpenIdConnectConstants.Claims.Scope, permission.Name);
                            });
                        }

                        // Add openid scopes
                        options.AddPolicy(OpenIddictConstants.Scopes.Roles, policy =>
                        {
                            policy.RequireClaim(OpenIdConnectConstants.Claims.Scope, OpenIddictConstants.Scopes.Roles);
                        });
                    }
                }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            ILoggerFactory loggerFactory, IApplicationLifetime appLifetime)
        {
            loggerFactory.AddSerilog();

            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:4200");   //listen to web/presentation application
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });

            //insert jwt auth server authentication
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();

            // Authenticate users on a separate server
            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                Audience = "onlineshop",
                Authority = "http://localhost:5000/",
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                RequireHttpsMetadata = false,
                TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = OpenIdConnectConstants.Claims.Name,
                    RoleClaimType = OpenIdConnectConstants.Claims.Role
                }
            });

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                Audience = "onlineshop",
                Authority = "http://localhost:5000/",
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                RequireHttpsMetadata = false,
                TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = OpenIdConnectConstants.Claims.Name,
                    RoleClaimType = OpenIdConnectConstants.Claims.Role
                }
            });

            appLifetime.ApplicationStopped.Register(Log.CloseAndFlush);

            app.UseAppBuilder(loggerFactory, new AutoFacEventDispatcher());

            app.UseMvc();
        }
    }
}
