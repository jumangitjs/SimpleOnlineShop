using System;

namespace SimpleOnlineShop.SimpleOnlineShop.Application.Web.DTO
{
    public class OrderData : IData
    {
        public long Id { get; set; }
        public string OrderDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}