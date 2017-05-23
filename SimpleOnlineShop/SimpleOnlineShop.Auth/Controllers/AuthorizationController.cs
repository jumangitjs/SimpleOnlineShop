using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNet.Security.OpenIdConnect.Extensions;
using AspNet.Security.OpenIdConnect.Primitives;
using AspNet.Security.OpenIdConnect.Server;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenIddict.Core;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure;

namespace SimpleOnlineShop.Auth.Controllers
{
    public class AuthorizationController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public AuthorizationController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("~/connect/logout")]
        public IActionResult Logout()
        {
            // Returning a SignOutResult will ask OpenIddict to redirect the user agent
            // to the post_logout_redirect_uri specified by the client application.
            return SignOut(OpenIdConnectServerDefaults.AuthenticationScheme);
        }

        [HttpPost("~/connect/token"), Produces("application/json")]
        public async Task<IActionResult> Exchange(OpenIdConnectRequest request)
        {
            if (request.IsPasswordGrantType())
            {
                var credentials = await _unitOfWork.Accounts
                    .Include("User.Roles.Role.Permissions.Permission")
                    .FirstOrDefaultAsync(c => c.Username == request.Username);
                
                if (credentials == null)
                {
                    return Forbid(OpenIdConnectServerDefaults.AuthenticationScheme);
                }

                if (!BCrypt.Net.BCrypt.Verify(request.Password, credentials.Password))
                    return Forbid(OpenIdConnectServerDefaults.AuthenticationScheme);

                // Create a new ClaimsIdentity holding the user identity.
                var identity = new ClaimsIdentity(
                    OpenIdConnectServerDefaults.AuthenticationScheme,
                    OpenIdConnectConstants.Claims.Name,
                    OpenIdConnectConstants.Claims.Role
                );
                // Add a "sub" claim containing the user identifier, and attach
                // the "access_token" destination to allow OpenIddict to store it
                // in the access token, so it can be retrieved from your controllers.

                identity.AddClaim(OpenIdConnectConstants.Claims.Username, credentials.Username,
                    OpenIdConnectConstants.Destinations.IdentityToken,
                    OpenIdConnectConstants.Destinations.AccessToken);
                identity.AddClaim("id", credentials.User.Id.ToString(),
                    OpenIdConnectConstants.Destinations.IdentityToken,
                    OpenIdConnectConstants.Destinations.AccessToken);
                identity.AddClaim(OpenIdConnectConstants.Claims.Subject, credentials.User.Id.ToString(), OpenIdConnectConstants.Destinations.IdentityToken);
                identity.AddClaim(OpenIdConnectConstants.Claims.Name, credentials.User.Name, OpenIdConnectConstants.Destinations.IdentityToken);
                identity.AddClaim(OpenIdConnectConstants.Claims.FamilyName, credentials.User.LastName, OpenIdConnectConstants.Destinations.IdentityToken);
                identity.AddClaim(OpenIdConnectConstants.Claims.GivenName, credentials.User.FirstName, OpenIdConnectConstants.Destinations.IdentityToken);

                // ... add other claims, if necessary.
                var principal = new ClaimsPrincipal(identity);

                // Claims will not be associated with specific destinations by default, so we must indicate whether they should
                // be included or not in access and identity tokens.

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true
                };

                // Create a new authentication ticket for the user's principal
                var ticket = new AuthenticationTicket(
                    principal,
                    authProperties,
                    OpenIdConnectServerDefaults.AuthenticationScheme);

                var roles = credentials.User.Roles.Select(r => r.Role);
                var permissions = roles.SelectMany(p => p.Permissions,
                    (role, permission) => permission.Permission.Name).ToList();

                // common scopes
                permissions.AddRange(new[]
                {
                    OpenIdConnectConstants.Scopes.OpenId,
                    OpenIdConnectConstants.Scopes.Email,
                    OpenIdConnectConstants.Scopes.Profile,
                    OpenIdConnectConstants.Scopes.OfflineAccess,
                    OpenIddictConstants.Scopes.Roles
                });

                // Include resources and scopes, as appropriate
                var scope = permissions.Intersect(request.GetScopes());

                // Set resource servers
                ticket.SetResources("onlineshop");
                ticket.SetScopes(scope);

                // Sign in the user
                return SignIn(ticket.Principal, ticket.Properties, ticket.AuthenticationScheme);
            }
            // TODO add refresh token grant type
            else
            {
                return BadRequest(new OpenIdConnectResponse
                {
                    Error = OpenIdConnectConstants.Errors.InvalidRequest,
                    ErrorDescription = "The specified grant type is not supported."
                });
            }
        }
    }
}