using System;
using System.Collections.Generic;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Inventory;

namespace SimpleOnlineShop.SimpleOnlineShop.Application.Web.DTO
{
    public class InventoryData : IData
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<InventoryProduct> InventoryProducts { get; set; } = new List<InventoryProduct>();
    }
}