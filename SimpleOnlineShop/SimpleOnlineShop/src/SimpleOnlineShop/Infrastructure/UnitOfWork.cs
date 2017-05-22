using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SimpleOnlineShop.SimpleOnlineShop.Domain;
using SimpleOnlineShop.SimpleOnlineShop.Domain.AccountAgg;
using SimpleOnlineShop.SimpleOnlineShop.Domain.AuthEntitiesAgg;
using SimpleOnlineShop.SimpleOnlineShop.Domain.InventoryAgg;
using SimpleOnlineShop.SimpleOnlineShop.Domain.UserAgg;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure
{
    public class UnitOfWork : DbContext, IUnitOfWork
    {
        #region domain logic
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryProduct> InventoryProducts { get; set; }
        #endregion

        #region auth entities

        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Account> Accounts { get; set; }

        #endregion

        public UnitOfWork() { }

        public UnitOfWork(DbContextOptions<UnitOfWork> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user =>
            {
                user.Property(u => u.Id).HasColumnName("id").UseNpgsqlSerialColumn();
                user.HasKey(u => u.Id);

                user.Property(u => u.FirstName).HasColumnName("first_name");
                user.Property(u => u.LastName).HasColumnName("last_name");
                user.Property(u => u.Gender).HasColumnName("gender");
                user.Property(u => u.Address).HasColumnName("address");
                user.Property(u => u.Email).HasColumnName("email");
                user.Property(u => u.ContactNo).HasColumnName("contact_no");

                user.HasMany(u => u.Roles).WithOne().HasForeignKey("user_id");
                user.HasOne(u => u.Account).WithOne(a => a.User).HasForeignKey<Account>("user_id");

                user.ForNpgsqlUseXminAsConcurrencyToken();

                user.ToTable("user");
            });

            modelBuilder.Entity<Account>(acc =>
            {
                acc.Property(a => a.Id).HasColumnName("id").UseNpgsqlSerialColumn();
                acc.HasKey(a => a.Id);

                acc.Property(a => a.Username).HasColumnName("username");
                acc.Property(a => a.Password).HasColumnName("password");

                acc.ForNpgsqlUseXminAsConcurrencyToken();

                acc.ToTable("credentials");
            });
            
            modelBuilder.Entity<Role>(role =>
            {
                role.Property(r => r.Id).HasColumnName("id");
                role.HasKey(r => r.Id);

                role.Property(r => r.Name).HasColumnName("name");
                role.Property(r => r.Description).HasColumnName("description");

                role.HasMany(r => r.Users).WithOne().HasForeignKey("role_id");
                role.HasMany(r => r.Permissions).WithOne().HasForeignKey("role_id");

                role.ForNpgsqlUseXminAsConcurrencyToken();

                role.ToTable("role");
            });

            modelBuilder.Entity<Permission>(permission =>
            {
                permission.Property(r => r.Id).HasColumnName("id");
                permission.HasKey(r => r.Id);

                permission.Property(r => r.Name).HasColumnName("name");
                permission.Property(r => r.Description).HasColumnName("description");

                permission.HasMany(r => r.Roles).WithOne().HasForeignKey("permission_id");

                permission.ForNpgsqlUseXminAsConcurrencyToken();

                permission.ToTable("permission");
            });

            modelBuilder.Entity<UserRole>(userRole =>
            {
                userRole.Property<long>("user_id").UseNpgsqlSerialColumn();
                userRole.Property<long>("role_id").UseNpgsqlSerialColumn();

                userRole.HasKey("user_id", "role_id");

                userRole.HasOne(ur => ur.User).WithMany(u => u.Roles).HasForeignKey("user_id");
                userRole.HasOne(ur => ur.Role).WithMany(r => r.Users).HasForeignKey("role_id");

                userRole.ForNpgsqlUseXminAsConcurrencyToken();

                userRole.ToTable("user_role");
            });

            modelBuilder.Entity<RolePermission>(rolePermission =>
            {
                rolePermission.Property<long>("role_id").UseNpgsqlSerialColumn();
                rolePermission.Property<long>("permission_id").UseNpgsqlSerialColumn();

                rolePermission.HasKey("permission_id", "role_id");

                rolePermission.HasOne(rp => rp.Permission).WithMany(p => p.Roles).HasForeignKey("permission_id");
                rolePermission.HasOne(rp => rp.Role).WithMany(r => r.Permissions).HasForeignKey("role_id");

                rolePermission.ForNpgsqlUseXminAsConcurrencyToken();

                rolePermission.ToTable("role_permission");
            });

            modelBuilder.Entity<Product>(product =>
            {
                product.Property(p => p.Id).HasColumnName("id").UseNpgsqlSerialColumn();
                product.HasKey(p => p.Id);

                product.Property(p => p.Name).HasColumnName("name");
                product.Property(p => p.Description).HasColumnName("description");
                product.Property(p => p.Brand).HasColumnName("brand");
                product.Property(p => p.Price).HasColumnName("price");
                
                product.ForNpgsqlUseXminAsConcurrencyToken();

                product.ToTable("product");
            });

            modelBuilder.Entity<InventoryProduct>(inventoryProduct =>
            {
                inventoryProduct.Property(ip => ip.Id).HasColumnName("id").UseNpgsqlSerialColumn();
                inventoryProduct.HasKey(ip => ip.Id);
                inventoryProduct.HasAlternateKey(ip => ip.UniqueId);

                inventoryProduct.Property(ip => ip.TimeAdded).HasColumnName("time_added");
                inventoryProduct.Property(ip => ip.UniqueId).HasColumnName("unique_id");

                inventoryProduct.HasOne(ip => ip.ProductInstance)
                    .WithMany().HasForeignKey("product_id").OnDelete(DeleteBehavior.Cascade);
                
                inventoryProduct.ForNpgsqlUseXminAsConcurrencyToken();

                inventoryProduct.ToTable("inventory_product");
            });

            modelBuilder.Entity<Inventory>(inventory =>
            {
                inventory.Property(i => i.Id).HasColumnName("id").UseNpgsqlSerialColumn();
                inventory.HasKey(i => i.Id);
                inventory.Property(i => i.Name).HasColumnName("name");
                inventory.Property(i => i.Description).HasColumnName("description");

                inventory.HasMany(i => i.InventoryProducts).WithOne().HasForeignKey("inventory_id")
                    .IsRequired(false).OnDelete(DeleteBehavior.Cascade);

                inventory.ForNpgsqlUseXminAsConcurrencyToken();

                inventory.ToTable("inventory");
            });

            modelBuilder.Entity<Order>(order =>
            {
                order.HasKey(o => o.Id);
                order.Property(o => o.Id).HasColumnName("id");

                order.Property(o => o.OrderDate).HasColumnName("order_date");
                order.Property(o => o.UserId).HasColumnName("customer_id");
                order.Property(o => o.ProductId).HasColumnName("product_id");

                order.HasOne(o => o.Product).WithMany().HasForeignKey(o => o.ProductId)
                    .IsRequired().OnDelete(DeleteBehavior.Restrict);
                order.HasOne(o => o.User).WithMany(o => o.Orders).HasForeignKey(o => o.UserId)
                    .IsRequired().OnDelete(DeleteBehavior.Restrict);

                order.ForNpgsqlUseXminAsConcurrencyToken();

                order.ToTable("order");
            });
        }

        public void Commit()
        {
           SaveChanges();
        }

        public void Rollback()
        {
            Dispose();
        }
    }
}