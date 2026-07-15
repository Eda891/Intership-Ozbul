using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PokedexApi.Domain.Interfaces;
using PokedexApi.Infrastructure.Persistence;
using PokedexApi.Infrastructure.Repositories;

namespace PokedexApi.Infrastructure
{
    //Registers the DbContext and Repository into the DI container, reads the SQLite connection string
    public static class ConfigureInfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PokedexDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPokemonRepository, PokemonRepository>();

            return services;
        }
    }
}
