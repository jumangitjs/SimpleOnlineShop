using Microsoft.EntityFrameworkCore;
using SimpleOnlineShop.SimpleOnlineShop.Domain;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Customer;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Inventory;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.Extension;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure
{
    public class UnitOfWork : DbContext, IUnitOfWork
    {
        public DbSet<Customer> Customers { get; set; }
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
                customer.Property(c => c.Id).HasColumnName("id");
                customer.HasKey(c => c.Id);

                customer.Property(c => c.FirstName).HasColumnName("first_name");
                customer.Property(c => c.LastName).HasColumnName("last_name");
                customer.Property(c => c.Gender).HasColumnName("gender");
                customer.Property(c => c.Address).HasColumnName("address");
                customer.Property(c => c.Email).HasColumnName("email");
                customer.Property(c => c.ContactNo).HasColumnName("contact_no");

                customer.HasMany(c => c.Orders).WithOne().HasForeignKey("customer_id");

                customer.ToTable("customer");
            });

            modelBuilder.Entity<Product>(product =>
            {
                product.Property(p => p.Id).HasColumnName("id");
                product.HasKey(p => p.Id);

                product.Property(p => p.Name).HasColumnName("name");
                product.Property(p => p.Description).HasColumnName("description");
                product.Property(p => p.Price).HasColumnName("price");

                product.HasMany(p => p.InventoryProduct)
                    .WithOne(ip => ip.ProductInstance)
                    .HasForeignKey("product_id");

                product.ToTable("product");
            });

            modelBuilder.Entity<InventoryProduct>(inventoryProduct =>
            {
                inventoryProduct.Property(ip => ip.Id).HasColumnName("id");
                inventoryProduct.HasKey(ip => ip.Id);
                inventoryProduct.HasAlternateKey(ip => ip.UniqueId);

                inventoryProduct.Property(ip => ip.TimeAdded).HasColumnName("time_added");
                inventoryProduct.Property(ip => ip.UniqueId).HasColumnName("unique_id");

                inventoryProduct.HasOne(ip => ip.ProductInstance)
                    .WithMany(p => p.InventoryProduct);
                
                inventoryProduct.ToTable("inventory_product");
            });

            modelBuilder.Entity<ProductInventoryList>(inventory =>
            {
                inventory.Property(i => i.Id).HasColumnName("id");
                inventory.HasKey(i => i.Id);
                inventory.Property(i => i.Name).HasColumnName("name");
                inventory.Property(i => i.Description).HasColumnName("description");

                inventory.HasMany(i => i.InventoryProducts).WithOne().HasForeignKey("inventory_id");

                inventory.ToTable("inventory");
            });

            modelBuilder.Entity<Order>(order =>
            {
                order.Property(o => o.Id).HasColumnName("id");
                order.HasKey(o => o.Id);
                order.Property(o => o.OrderDate).HasColumnName("order_date");

                order.HasMany(o => o.Products).WithOne().HasForeignKey("product_id");
                
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