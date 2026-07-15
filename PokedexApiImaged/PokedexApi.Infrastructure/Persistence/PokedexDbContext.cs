using Microsoft.EntityFrameworkCore;
using PokedexApi.Domain.Entities;

namespace PokedexApi.Infrastructure.Persistence
{
    public class PokedexDbContext : DbContext
    {
        public PokedexDbContext(DbContextOptions<PokedexDbContext> options) : base(options)
        {
        }

        public DbSet<Pokemon> Pokemons => Set<Pokemon>();
    }
}
