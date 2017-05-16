using System;

namespace SimpleOnlineShop.SimpleOnlineShop.Application.Web.DTO
{
    public class InventoryProductData : IData
    {
        public long Id { get; set; }
        public string UniqueId { get; set; }
        public DateTime TimeAdded { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}