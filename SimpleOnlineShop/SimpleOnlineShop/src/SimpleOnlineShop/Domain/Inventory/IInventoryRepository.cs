namespace SimpleOnlineShop.SimpleOnlineShop.Domain.Inventory
{
    public interface IInventoryRepository : IRepository<ProductInventoryList>
    {
        ProductInventoryList FindByName(string name);
    }
}