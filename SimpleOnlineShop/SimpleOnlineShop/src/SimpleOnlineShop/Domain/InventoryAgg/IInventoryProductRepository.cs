namespace SimpleOnlineShop.SimpleOnlineShop.Domain.InventoryAgg
{
    public interface IInventoryProductRepository : IRepository<InventoryProduct>
    {
        InventoryProduct FindByName(string name);
    }
}