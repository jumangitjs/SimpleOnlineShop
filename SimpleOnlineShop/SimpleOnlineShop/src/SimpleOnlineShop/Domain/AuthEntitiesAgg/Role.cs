using System.Collections.Generic;

namespace SimpleOnlineShop.SimpleOnlineShop.Domain.AuthEntitiesAgg
{
    public class Role : IAggregateRoot
    {
        public long Id { get; set; }

        public string Name { get; protected set; }
        public string Description { get; protected set; }
        
        public IList<UserRole> Users { get; set; }
        public IList<RolePermission> Permissions { get; set; }
    }
}