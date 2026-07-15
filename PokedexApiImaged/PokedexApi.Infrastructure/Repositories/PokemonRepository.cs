using Microsoft.EntityFrameworkCore;
using PokedexApi.Domain.Entities;
using PokedexApi.Domain.Interfaces;
using PokedexApi.Infrastructure.Persistence;

namespace PokedexApi.Infrastructure.Repositories
{
    //The actual implementation of IPokemonRepository; uses EF Core to read/write to SQLite
    public class PokemonRepository : IPokemonRepository
    {
        private readonly PokedexDbContext _context;

        public PokemonRepository(PokedexDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pokemon>> GetAllAsync()
        {
            return await _context.Pokemons.AsNoTracking().ToListAsync();
        }

        public async Task<Pokemon?> GetByIdAsync(int id)
        {
            return await _context.Pokemons.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Pokemon> CreateAsync(Pokemon pokemon)
        {
            _context.Pokemons.Add(pokemon);
            await _context.SaveChangesAsync();
            return pokemon;
        }

        public async Task UpdateAsync(Pokemon pokemon)
        {
            _context.Pokemons.Update(pokemon);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon is not null)
            {
                _context.Pokemons.Remove(pokemon);
                await _context.SaveChangesAsync();
            }
        }
    }
}
