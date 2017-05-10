using System;
using System.Collections.Generic;

namespace SimpleOnlineShop.SimpleOnlineShop.Application.Web.DTO
{
    public class OrderData : IData
    {
        public long Id { get; set; }
        public DateTime OrderDate { get; set; }
        public List<ProductData> Products { get; set; } = new List<ProductData>();
    }
}