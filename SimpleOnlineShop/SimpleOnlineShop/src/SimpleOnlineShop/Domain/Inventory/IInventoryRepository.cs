namespace SimpleOnlineShop.SimpleOnlineShop.Domain.Inventory
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        Inventory FindByName(string name);
    }
}