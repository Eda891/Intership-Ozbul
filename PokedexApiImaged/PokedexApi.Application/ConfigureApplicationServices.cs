using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PokedexApi.Application
{
    //Registers MediatR and AutoMapper into the DI container.
    public static class ConfigureApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Bu assembly içindeki tüm Command/Query Handler'ları otomatik kaydeder
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // AutoMapper profillerini kaydeder
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
