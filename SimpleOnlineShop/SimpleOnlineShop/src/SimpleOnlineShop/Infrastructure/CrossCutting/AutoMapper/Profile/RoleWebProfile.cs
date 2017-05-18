using System.Linq;
using SimpleOnlineShop.SimpleOnlineShop.Application.Web.DTO;
using SimpleOnlineShop.SimpleOnlineShop.Domain.AuthEntitiesAgg;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.Extension;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.AutoMapper.Profile
{
    public class RoleWebProfile : global::AutoMapper.Profile
    {
        public RoleWebProfile()
        {
            var roleMapper = CreateMap<Role, RoleData>();
            roleMapper.ForMember(dto => dto.Id, mc => mc.MapFrom(e => e.Id));
            roleMapper.ForMember(dto => dto.Name, mc => mc.MapFrom(e => e.Name));
            roleMapper.ForMember(dto => dto.Description, mc => mc.MapFrom(e => e.Description));
            roleMapper.ForMember(dto => dto.Permissions, mc => mc.MapFrom(e => e.Permissions
                .Select(p => p.Permission)
                .AsEnumerableData<PermissionData>()));

            var mapper = CreateMap<Permission, PermissionData>();

            mapper.ForMember(dto => dto.Id, mc => mc.MapFrom(e => e.Id));
            mapper.ForMember(dto => dto.Name, mc => mc.MapFrom(e => e.Name));
            mapper.ForMember(dto => dto.Description, mc => mc.MapFrom(e => e.Description));
        }
    }
}