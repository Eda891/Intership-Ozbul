using PokedexApi.Domain.Entities;

namespace PokedexApi.Domain.Interfaces
{
    //The contract for database operations,just an interface, no real implementation here.
    public interface IPokemonRepository
    {
        Task<List<Pokemon>> GetAllAsync();
        Task<Pokemon?> GetByIdAsync(int id);
        Task<Pokemon> CreateAsync(Pokemon pokemon);
        Task UpdateAsync(Pokemon pokemon);
        Task DeleteAsync(int id);
    }
}
