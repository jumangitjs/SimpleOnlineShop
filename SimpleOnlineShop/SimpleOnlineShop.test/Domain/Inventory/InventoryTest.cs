using System.Linq;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Inventory;
using Xunit;

namespace SimpleOnlineShop.test.Domain.Inventory
{
    public class InventoryTest
    {
        [Fact]
        public SimpleOnlineShop.Domain.Inventory.Inventory TestInventory()
        {
            return SimpleOnlineShop.Domain.Inventory.Inventory.Create("Test", "test desc");
        }

        [Fact]
        public void AddProductToInventory()
        {
            var inventory = TestInventory();
            var product = Product.Create( "testprod", "testbrand","desc", 10);
            var inventory_product = InventoryProduct.Create("123123", product);

            inventory.InventoryProducts.Add(inventory_product);
            Assert.NotNull(inventory.InventoryProducts.First(p => p.ProductInstance == product));
        }
    }
}