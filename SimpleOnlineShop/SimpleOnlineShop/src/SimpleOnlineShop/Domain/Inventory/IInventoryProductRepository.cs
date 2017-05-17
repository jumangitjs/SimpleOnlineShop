namespace SimpleOnlineShop.SimpleOnlineShop.Domain.Inventory
{
    public interface IInventoryProductRepository : IRepository<InventoryProduct>
    {
        InventoryProduct FindByName(string name);
    }
}