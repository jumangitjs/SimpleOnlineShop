using SimpleOnlineShop.SimpleOnlineShop.Application.Web.DTO;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Inventory;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.Extension;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.AutoMapper.Profile
{
    public class InventoryWebProfile : global::AutoMapper.Profile
    {
        public InventoryWebProfile()
        {
            var mapper = CreateMap<ProductInventoryList, ProductInventoryListData>();

            mapper.ForMember(dto => dto.Id, mc => mc.MapFrom(e => e.Id));
            mapper.ForMember(dto => dto.Name, mc => mc.MapFrom(e => e.Name));
            mapper.ForMember(dto => dto.Description, mc => mc.MapFrom(e => e.Description));
            mapper.ForMember(dto => dto.InventoryProducts, mc => mc.MapFrom(e => e.InventoryProducts.AsEnumerableData<InventoryProductData>()));
            
            var inventoryProductMapper = CreateMap<InventoryProduct, InventoryProductData>();

            inventoryProductMapper.ForMember(dto => dto.Id, mc => mc.MapFrom(e => e.Id));
            inventoryProductMapper.ForMember(dto => dto.UniqueId, mc => mc.MapFrom(e => e.UniqueId));
            inventoryProductMapper.ForMember(dto => dto.TimeAdded, mc => mc.MapFrom(e => e.TimeAdded));
            inventoryProductMapper.ForMember(dto => dto.ProductInstance, mc => mc.MapFrom(e => e.ProductInstance.AsData<ProductData>()));

            var productMapper = CreateMap<Product, ProductData>();

            productMapper.ForMember(dto => dto.Id, mc => mc.MapFrom(e => e.Id));
            productMapper.ForMember(dto => dto.Name, mc => mc.MapFrom(e => e.Name));
            productMapper.ForMember(dto => dto.Description, mc => mc.MapFrom(e => e.Description));
            productMapper.ForMember(dto => dto.Price, mc => mc.MapFrom(e => e.Price));

        }
    }
}