namespace SimpleOnlineShop.SimpleOnlineShop.Application.Web.DTO
{
    public class ProductData : IData
    {
        public long Id { get; set; }
        public string ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}