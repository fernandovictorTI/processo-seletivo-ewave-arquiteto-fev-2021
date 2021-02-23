using AutoMapper;

namespace FavoDeMel.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
                cfg.AddProfile(new QueryModelToDomainMappingProfile());
                cfg.AddProfile(new EntityToDtoMappingProfile());
            });
        }
    }
}
