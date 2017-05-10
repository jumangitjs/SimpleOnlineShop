namespace SimpleOnlineShop.SimpleOnlineShop.Domain.Inventory
{
    public interface IProductInventoryRepository : IRepository<ProductInventoryList>
    {
        ProductInventoryList FindByName(string name);
    }
}