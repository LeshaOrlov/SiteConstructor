using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SiteConstructor.Framework.Repository;
using SiteConstructor.GenericControllers.Repository;
using System;

namespace SiteConstructor.GenericControllers
{
    public static class ServiceExtensions
    {
        public static void AddMvcGenericController(this IServiceCollection services)
        {
            services.AddMvcCore(o => o.Conventions.Add(
                    new GenericControllerRouteConvention()
                )).
                ConfigureApplicationPartManager(m =>
                    m.FeatureProviders.Add(new GenericControllerFeatureProvider()
                ));
        }

        public static void AddGenericController(this IMvcBuilder builder)
        {
            builder.ConfigureApplicationPartManager(m =>
                    m.FeatureProviders.Add(new GenericControllerFeatureProvider()
                ));
        }

        public static void AddEFGenericRepository<TDbContext>(this IServiceCollection services)
            where TDbContext : DbContext
        {
            var ef = typeof(EFGenericRepository<,>).AddGenericType(1, typeof(TDbContext));
            services.AddScoped(typeof(IGenericRepository<>), ef);
        }

        //public static void AddGenericRepository<TGenericRepository>(this IServiceCollection services)
        //{
        //    services.AddScoped(typeof(IGenericRepository<>), typeof(TGenericRepository));
        //}

    }
}
