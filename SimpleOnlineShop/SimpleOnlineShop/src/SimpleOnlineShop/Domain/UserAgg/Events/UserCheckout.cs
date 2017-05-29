using System.Collections.Generic;

namespace SimpleOnlineShop.SimpleOnlineShop.Domain.UserAgg.Events
{
    public class UserCheckout : IDomainEvent
    {
        public IList<Order> Orders { get; set; }
        public double GrandTotal { get; set; }
    }
}