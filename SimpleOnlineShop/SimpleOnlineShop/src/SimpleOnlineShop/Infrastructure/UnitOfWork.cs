using Microsoft.EntityFrameworkCore;
using SimpleOnlineShop.SimpleOnlineShop.Domain;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Customer;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Inventory;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure
{
    public class UnitOfWork : DbContext, IUnitOfWork
    {
        public DbSet<Customer> Customers { get; set; }
        //public DbSet<Inventory> Inventories { get; set; }

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
//                customer.HasMany(c => c.Products).WithOne().HasForeignKey("products_id");

                customer.ToTable("customer");
            });

//            modelBuilder.Entity<Inventory>(inventory =>
//            {
//                inventory.Property(i => i.Id).HasColumnName("id");
//                inventory.HasKey(i => i.Id);
//                inventory.Property(i => i.Name).HasColumnName("name");
//
//                inventory.HasMany(i => i.Products).WithOne().HasForeignKey("inventory_id");
//
//                inventory.ToTable("inventory");
//            });
//
//            modelBuilder.Entity<Product>(product =>
//            {
//                product.Property(p => p.Id).HasColumnName("id");
//                product.HasKey(p => p.Id);
//                product.Property(p => p.Name).HasColumnName("name");
//                product.Property(p => p.Description).HasColumnName("description");
//                product.Property(p => p.ItemId).HasColumnName("item_id");
//                product.Property(p => p.Price).HasColumnName("price");
//                product.Property(p => p.Quantity).HasColumnName("quantity");
//
//                product.ToTable("product");
//            });
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