using RickAndMortyApi.DAL.Models;
using RickAndMortyApi.Models;
using AutoMapper;

namespace RickAndMortyApi.Extensions
{
    public static class MappingExtensions
    {
        public static UserDto ToModel(this User user)
        {
            return Mapper<User, UserDto>(user, cfg =>
            {
                cfg.CreateMap<User, UserDto>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name))
                 .ForMember(dest => dest.LastName, opt => opt.MapFrom(c => c.LastName))
                 .ForMember(dest => dest.Login, opt => opt.MapFrom(c => c.UserName));
            });
        }

        public static User ToDomain(this UserDto dto)
        {
            return Mapper<UserDto, User>(dto, cfg =>
            {
                cfg.CreateMap<UserDto, User>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name))
                 .ForMember(dest => dest.LastName, opt => opt.MapFrom(c => c.LastName))
                 .ForMember(dest => dest.UserName, opt => opt.MapFrom(c => c.Login));               
            });
        }
        public static CharacterDto ToModel(this Character character)
        {
            return Mapper<Character, CharacterDto>(character, cfg => { cfg.CreateMap<Character, CharacterDto>(); });
        }

        public static Character ToDomain(this CharacterDto dto)
        {
            return Mapper<CharacterDto, Character>(dto, cfg => { cfg.CreateMap<CharacterDto, Character>(); });
        }

        private static TDestination Mapper<TSource, TDestination>(
            this TSource source,
            Action<IMapperConfigurationExpression> configure)
        {
            var config = new MapperConfiguration(configure);
            var mapper = config.CreateMapper();
            var destination = mapper.Map<TDestination>(source);
            return destination;
        }
    }
}
