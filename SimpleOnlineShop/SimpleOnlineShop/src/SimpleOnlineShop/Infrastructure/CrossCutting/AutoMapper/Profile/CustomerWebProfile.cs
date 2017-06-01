using SimpleOnlineShop.SimpleOnlineShop.Application.Web.DTO;
using SimpleOnlineShop.SimpleOnlineShop.Domain.UserAgg;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.Extension;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.AutoMapper.Profile
{
    public class CustomerWebProfile : global::AutoMapper.Profile
    {
        public CustomerWebProfile()
        {

            var orderMapper = CreateMap<Order, OrderData>();

            orderMapper.ForMember(dto => dto.Id, mc => mc.MapFrom(e => e.Id));
            orderMapper.ForMember(dto => dto.OrderDate, mc => mc.MapFrom(e => e.OrderDate.ToString("O")));
            orderMapper.ForMember(dto => dto.Name, mc => mc.MapFrom(e => e.Product.Name));
            orderMapper.ForMember(dto => dto.Description, mc => mc.MapFrom(e => e.Product.Description));
            orderMapper.ForMember(dto => dto.Price, mc => mc.MapFrom(e => e.Product.Price));

            var mapper = CreateMap<User, UserData>();

            mapper.ForMember(dto => dto.Id, mc => mc.MapFrom(e => e.Id));
            mapper.ForMember(dto => dto.FirstName, mc => mc.MapFrom(e => e.FirstName));
            mapper.ForMember(dto => dto.LastName, mc => mc.MapFrom(e => e.LastName));
            mapper.ForMember(dto => dto.Name, mc => mc.MapFrom(e => e.Name));
            mapper.ForMember(dto => dto.Gender, mc => mc.MapFrom(e => e.Gender.ToString()));
            mapper.ForMember(dto => dto.Address, mc => mc.MapFrom(e => e.Address));
            mapper.ForMember(dto => dto.Email, mc => mc.MapFrom(e => e.Email));
            mapper.ForMember(dto => dto.ContactNo, mc => mc.MapFrom(e => e.ContactNo));
            mapper.ForMember(dto => dto.Orders, mc => mc.MapFrom(e => e.Orders.AsEnumerableData<OrderData>()));
            mapper.ForMember(dto => dto.GrandTotal, mc => mc.MapFrom(e => e.GrandTotal));

        }
    }
}