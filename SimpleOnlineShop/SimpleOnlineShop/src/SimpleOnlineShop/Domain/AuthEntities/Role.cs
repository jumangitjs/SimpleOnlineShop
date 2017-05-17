using System.Collections.Generic;

namespace SimpleOnlineShop.SimpleOnlineShop.Domain.AuthEntities
{
    public class Role : IAgreggateRoot
    {
        public long Id { get; set; }

        public string Name { get; protected set; }
        public string Description { get; protected set; }
        
        public IList<UserRole> Users { get; set; }
        public IList<RolePermission> Permissions { get; set; }
    }
}