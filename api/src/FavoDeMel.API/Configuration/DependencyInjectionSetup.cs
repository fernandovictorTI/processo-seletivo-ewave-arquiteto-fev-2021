using FavoDeMel.Infra.CrossCutting.IOC;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FavoDeMel.API.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public static class DependencyInjectionSetup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
