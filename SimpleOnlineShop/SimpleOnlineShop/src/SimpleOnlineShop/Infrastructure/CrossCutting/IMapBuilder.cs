namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting
{
    public interface IMapBuilder
    {
        IMapBuilder Map(object source);

        TDestination To<TDestination>(TDestination destination);
        TDestination To<TDestination>();
    }
}