using System.Collections.Generic;

namespace SimpleOnlineShop.SimpleOnlineShop.Application.Web.DTO
{
    public class ProductInventoryListData : IData
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<InventoryProductData> InventoryProducts { get; set; } = new List<InventoryProductData>();
    }
}