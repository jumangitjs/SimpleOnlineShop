using System;

namespace SimpleOnlineShop.SimpleOnlineShop.Application.Web.DTO
{
    public class InventoryProductData : IData
    {
        public long Id { get; set; }
        public string UniqueId { get; set; }
        public DateTime TimeAdded { get; set; }
        public ProductData ProductInstance { get; set; }
    }
}