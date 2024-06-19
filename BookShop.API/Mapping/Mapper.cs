using AutoMapper;
namespace BookShop.API.Mapping
{
    public class Mapper<TSource, TDestination> where TDestination : class where TSource : class
    {
        private readonly IMapper _mapper;
        public Mapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
                cfg.CreateMap<TDestination, TSource>();
            });
            _mapper = config.CreateMapper();
        }
        public TDestination Map(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }
        public TSource Map(TDestination source)
        {
            return _mapper.Map<TDestination, TSource>(source);
        }
    }
}
