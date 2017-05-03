namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
        TDestination MapTo<TDestination>(object source);

        IMapBuilder Map(object source);
    }

}