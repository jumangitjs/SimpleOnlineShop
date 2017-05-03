using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting
{
    public class Mapper : IMapper
    {
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return MapTo<TDestination>(source);
        }

        public TDestination MapTo<TDestination>(object source)
        {
            return Map(source).To<TDestination>();
        }

        public IMapBuilder Map(object source)
        {
            return new MapBuilder(source);
        }

        internal class MapBuilder : IMapBuilder
        {
            private readonly List<object> _sources = new List<object>();

            public MapBuilder(object source)
            {
                _sources.Add(source);
            }

            public IMapBuilder Map(object source)
            {
                _sources.Add(source);
                return this;
            }

            public TDestination To<TDestination>(TDestination destination)
            {
                _sources.ForEach(source => Map(source, destination));
                return destination;
            }

            private static TDestination Map<TDestination>(object source, TDestination destination)
            {
                return destination != null
                    ? (TDestination) global::AutoMapper.Mapper.Map(source, destination, source.GetType(), typeof(TDestination))
                    : global::AutoMapper.Mapper.Map<TDestination>(source);
            }

            private static object Map(object source, object destination, Type destinationType)
            {
                return destination != null
                    ? global::AutoMapper.Mapper.Map(source, destination, source.GetType(), destinationType)
                    : global::AutoMapper.Mapper.Map(source, source.GetType(), destinationType);
            }

            public object ToType(Type destinationType)
            {
                return _sources.Aggregate<object, object>(null, (destination, source) => Map(source, destination, destinationType));
            }

            public TDestination To<TDestination>()
            {
                return _sources.Aggregate(default(TDestination), (destination, source) => Map(source, destination));
            }
        }
    }
}