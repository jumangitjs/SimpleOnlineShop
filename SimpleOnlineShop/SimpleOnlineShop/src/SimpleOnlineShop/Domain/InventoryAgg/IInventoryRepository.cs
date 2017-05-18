namespace SimpleOnlineShop.SimpleOnlineShop.Domain.InventoryAgg
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        Inventory FindByName(string name);
    }
}