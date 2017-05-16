using Microsoft.EntityFrameworkCore;
using SimpleOnlineShop.SimpleOnlineShop.Domain;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Customer;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Inventory;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure
{
    public class UnitOfWork : DbContext, IUnitOfWork
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductInventoryList> Inventories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=127.0.0.1;" +
                "Username=postgres;" +
                "Password=postgres;" +
                "Database=onlineshop;" +
                "Port=5432;"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(customer =>
            {
                customer.Property(c => c.Id).HasColumnName("id").UseNpgsqlSerialColumn();
                customer.HasKey(c => c.Id);

                customer.Property(c => c.FirstName).HasColumnName("first_name");
                customer.Property(c => c.LastName).HasColumnName("last_name");
                customer.Property(c => c.Gender).HasColumnName("gender");
                customer.Property(c => c.Address).HasColumnName("address");
                customer.Property(c => c.Email).HasColumnName("email");
                customer.Property(c => c.ContactNo).HasColumnName("contact_no");
                
                customer.ForNpgsqlUseXminAsConcurrencyToken();

                customer.ToTable("customer");
            });

            modelBuilder.Entity<Product>(product =>
            {
                product.Property(p => p.Id).HasColumnName("id").UseNpgsqlSerialColumn();
                product.HasKey(p => p.Id);

                product.Property(p => p.Name).HasColumnName("name");
                product.Property(p => p.Description).HasColumnName("description");
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
                    .WithMany().HasForeignKey("product_id");
                
                inventoryProduct.ForNpgsqlUseXminAsConcurrencyToken();

                inventoryProduct.ToTable("inventory_product");
            });

            modelBuilder.Entity<ProductInventoryList>(inventory =>
            {
                inventory.Property(i => i.Id).HasColumnName("id").UseNpgsqlSerialColumn();
                inventory.HasKey(i => i.Id);
                inventory.Property(i => i.Name).HasColumnName("name");
                inventory.Property(i => i.Description).HasColumnName("description");

                inventory.HasMany(i => i.InventoryProducts).WithOne().HasForeignKey("inventory_id");

                inventory.ForNpgsqlUseXminAsConcurrencyToken();

                inventory.ToTable("inventory");
            });

            modelBuilder.Entity<Order>(order =>
            {
                order.HasKey(o => o.Id);
                order.Property(o => o.Id).HasColumnName("id");

                order.Property(o => o.OrderDate).HasColumnName("order_date");
                order.Property(o => o.CustomerId).HasColumnName("customer_id");
                order.Property(o => o.ProductId).HasColumnName("product_id");

                order.HasOne(o => o.Product).WithMany().HasForeignKey(o => o.ProductId).IsRequired();
                order.HasOne(o => o.Customer).WithMany(o => o.Orders).HasForeignKey(o => o.CustomerId).IsRequired();

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