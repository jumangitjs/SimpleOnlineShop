using System.Collections.Generic;

namespace SimpleOnlineShop.SimpleOnlineShop.Domain.AuthEntitiesAgg
{
    public class Permission : IEntity
    {
        public long Id { get; set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public IList<RolePermission> Roles { get; set; }
    }
}