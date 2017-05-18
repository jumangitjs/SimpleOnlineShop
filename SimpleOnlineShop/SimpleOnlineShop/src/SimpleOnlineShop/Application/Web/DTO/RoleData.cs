using System.Collections.Generic;

namespace SimpleOnlineShop.SimpleOnlineShop.Application.Web.DTO
{
    public class RoleData : IData
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public IList<PermissionData> Permissions { get; set; }
    }
}