using System.Collections.Generic;
using SimpleOnlineShop.SimpleOnlineShop.Application;
using SimpleOnlineShop.SimpleOnlineShop.Domain;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.AutoMapper.Profile;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.Extension
{
    public static class DataPresenataion
    {

        private static readonly Mapper Mapper = new Mapper();

        static DataPresenataion()
        {
            global::AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CustomerWebProfile>();
                cfg.AddProfile<InventoryWebProfile>();
            });
        }

        public static TData AsData<TData>(this IEntity item)
            where TData : IData
        {
            return Mapper.MapTo<TData>(item);
        }

        public static ICollection<TData> AsCollection<TData>(this ICollection<IEntity> items)
            where TData : IData
        {
            return Mapper.MapTo<ICollection<TData>>(items);
        }

        public static IEnumerable<TData> AsEnumerable<TData>(this IEnumerable<IEntity> items)
            where TData : IData
        {
            return Mapper.MapTo<IEnumerable<TData>>(items);
        }

    }
}