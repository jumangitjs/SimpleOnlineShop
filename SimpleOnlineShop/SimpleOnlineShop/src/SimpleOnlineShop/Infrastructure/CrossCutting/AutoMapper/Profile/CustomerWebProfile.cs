using SimpleOnlineShop.SimpleOnlineShop.Application.Web.DTO;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Customer;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Inventory;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.Extension;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.AutoMapper.Profile
{
    public class CustomerWebProfile : global::AutoMapper.Profile
    {
        public CustomerWebProfile()
        {
            var mapper = CreateMap<Customer, CustomerData>();

            mapper.ForMember(dto => dto.Id, mc => mc.MapFrom(e => e.Id));
            mapper.ForMember(dto => dto.FirstName, mc => mc.MapFrom(e => e.FirstName));
            mapper.ForMember(dto => dto.LastName, mc => mc.MapFrom(e => e.LastName));
            mapper.ForMember(dto => dto.Name, mc => mc.MapFrom(e => e.Name));
            mapper.ForMember(dto => dto.Gender, mc => mc.MapFrom(e => e.Gender.ToString()));
            mapper.ForMember(dto => dto.Address, mc => mc.MapFrom(e => e.Address));
            mapper.ForMember(dto => dto.Email, mc => mc.MapFrom(e => e.Email));
            mapper.ForMember(dto => dto.ContactNo, mc => mc.MapFrom(e => e.ContactNo));
            mapper.ForMember(dto => dto.Orders, mc => mc.MapFrom(e => e.Orders.AsEnumerable<OrderData>()));

            var orderMapper = CreateMap<Order, OrderData>();

            orderMapper.ForMember(dto => dto.Id, mc => mc.MapFrom(e => e.Id));
            orderMapper.ForMember(dto => dto.OrderDate, mc => mc.MapFrom(e => e.OrderDate));
            orderMapper.ForMember(dto => dto.Products, mc => mc.MapFrom(e => e.Products.AsEnumerable<ProductData>()));

            var productMapper = CreateMap<Product, ProductData>();

            productMapper.ForMember(dto => dto.Name, mc => mc.MapFrom(e => e.Name));
            productMapper.ForMember(dto => dto.Id, mc => mc.MapFrom(e => e.Id));
            productMapper.ForMember(dto => dto.Description, mc => mc.MapFrom(e => e.Description));
            productMapper.ForMember(dto => dto.Price, mc => mc.MapFrom(e => e.Price));
        }
    }

   
}