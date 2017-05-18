namespace SimpleOnlineShop.SimpleOnlineShop.Application.Web.DTO
{
    public class PermissionData : IData
    {
        public long Id { get; set; }

        public string Name { get; protected set; }
        public string Description { get; protected set; }
    }
}