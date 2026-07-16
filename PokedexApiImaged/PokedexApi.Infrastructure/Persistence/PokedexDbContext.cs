using Microsoft.EntityFrameworkCore;
using PokedexApi.Domain.Entities;

namespace PokedexApi.Infrastructure.Persistence
{
    //EF Cores database context class
    public class PokedexDbContext : DbContext
    {
        public PokedexDbContext(DbContextOptions<PokedexDbContext> options) : base(options)
        {
        }

        public DbSet<Pokemon> Pokemons => Set<Pokemon>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Stats are not stored in a separate table, but as columns in the Pokémon table (owned type)
            modelBuilder.Entity<Pokemon>().OwnsOne(p => p.Stats);
        }
    }
}
