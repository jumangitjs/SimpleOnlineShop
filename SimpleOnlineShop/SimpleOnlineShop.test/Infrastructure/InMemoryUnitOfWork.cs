using Microsoft.EntityFrameworkCore;
using SimpleOnlineShop.SimpleOnlineShop.Domain;
using SimpleOnlineShop.SimpleOnlineShop.Domain.InventoryAgg;
using SimpleOnlineShop.SimpleOnlineShop.Domain.UserAgg;

namespace SimpleOnlineShop.test.Infrastructure
{
    public class InMemoryUnitOfWork : DbContext, IUnitOfWork
    {

        public DbSet<User> Customers { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("online_shop");
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