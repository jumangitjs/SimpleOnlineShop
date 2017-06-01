using SimpleOnlineShop.SimpleOnlineShop.Application.Web.DTO;
using SimpleOnlineShop.SimpleOnlineShop.Domain.InventoryAgg;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.Extension;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.AutoMapper.Profile
{
    public class InventoryWebProfile : global::AutoMapper.Profile
    {
        public InventoryWebProfile()
        {

            var mapper = CreateMap<Inventory, InventoryData>();

            mapper.ForMember(dto => dto.Id, mc => mc.MapFrom(e => e.Id));
            mapper.ForMember(dto => dto.Name, mc => mc.MapFrom(e => e.Name));
            mapper.ForMember(dto => dto.Description, mc => mc.MapFrom(e => e.Description));
            mapper.ForMember(dto => dto.InventoryProducts, mc => mc.MapFrom(e => e.InventoryProducts.AsEnumerableData<InventoryProductData>()));
            
            var inventoryProductMapper = CreateMap<InventoryProduct, InventoryProductData>();

            inventoryProductMapper.ForMember(dto => dto.Id, mc => mc.MapFrom(e => e.Id));
            inventoryProductMapper.ForMember(dto => dto.UniqueId, mc => mc.MapFrom(e => e.UniqueId));
            inventoryProductMapper.ForMember(dto => dto.DateAdded, mc => mc.MapFrom(e => e.TimeAdded.ToString("O")));
            inventoryProductMapper.ForMember(dto => dto.Id, mc => mc.MapFrom(e => e.Id));
            inventoryProductMapper.ForMember(dto => dto.Name, mc => mc.MapFrom(e => e.ProductInstance.Name));
            inventoryProductMapper.ForMember(dto => dto.Brand, mc => mc.MapFrom(e => e.ProductInstance.Brand));
            inventoryProductMapper.ForMember(dto => dto.Description, mc => mc.MapFrom(e => e.ProductInstance.Description));
            inventoryProductMapper.ForMember(dto => dto.Price, mc => mc.MapFrom(e => e.ProductInstance.Price));

        }
    }
}