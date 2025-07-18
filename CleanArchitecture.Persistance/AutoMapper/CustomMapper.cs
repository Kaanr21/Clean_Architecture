using AutoMapper;
using AutoMapper.Internal;
using CleanArchitecture.Application.Interfaces.AutoMapper;

namespace CleanArchitecture.Persistance.AutoMapper
{
    public class CustomMapper : ICustomMapper
    {
        public static List<TypePair> typePairs = new();

        private IMapper mapperContainer;

        public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
        {
            Config<TDestination, TSource>(5, ignore);

            return mapperContainer.Map<TSource, TDestination>(source);
        }

        public IList<TDestination> Map<TDestination, TSource>(List<TSource> source, string? ignore = null)
        {
            Config<TDestination, TSource>(5, ignore);

            return mapperContainer.Map<IList<TSource>, IList<TDestination>>(source);
        }

        public TDestination map<TDestination, TSource>(object source, string? ignore = null)
        {
            Config<TDestination, object>(5, ignore);

            return mapperContainer.Map<TDestination>(source);
        }

        public IList<TDestination> map<TDestination>(IList<object> source, string? ignore = null)
        {
            Config<TDestination, IList<object>>(5, ignore);

            return mapperContainer.Map<IList<TDestination>>(source);
        }

        protected void Config<TDestination, TSource>(int depth = 5, string? ignore = null)
        {
            var typePair = new TypePair(typeof(TSource), typeof(TDestination));

            if (typePairs.Any(a =>
            a.DestinationType == typePair.DestinationType &&
            a.SourceType == typePair.SourceType &&
            ignore is null))
                return;

            typePairs.Add(typePair);

            var config = new MapperConfiguration(cfg =>
            {
                foreach (var item in typePairs)
                {
                    var map = cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth);

                    if (!string.IsNullOrEmpty(ignore))
                    {
                        map.ForAllMembers(opt =>
                        {
                            if (opt.DestinationMember.Name == ignore)
                                opt.Ignore();
                        });
                    }

                    map.ReverseMap();
                }
            });

            mapperContainer = config.CreateMapper();
        }

    }
}
