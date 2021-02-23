using FavoDeMel.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using AutoMapper;

namespace FavoDeMel.API.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public static class AutoMapperSetup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddAutoMapper(typeof(Startup), 
                typeof(ViewModelToDomainMappingProfile), 
                typeof(EntityToDtoMappingProfile),
                typeof(QueryModelToDomainMappingProfile));
            AutoMapperConfig.RegisterMappings();
        }
    }
}
