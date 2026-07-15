using System.ComponentModel.DataAnnotations;

namespace PokedexApi.Application.DTOs
{
    // API'ye gelen ekleme isteği
    public record CreatePokemonRequest(
        [Required][StringLength(50)] string Name,
        [Required][StringLength(20)] string Height,
        [Required][StringLength(20)] string Weight,
        [Required][StringLength(50)] string Category,
        [Required][StringLength(50)] string Abilities,
        [StringLength(300)] string? ImageUrl
    );

    // API'ye gelen güncelleme isteği
    public record UpdatePokemonRequest(
        int Id,
        [Required][StringLength(50)] string Name,
        [Required][StringLength(20)] string Height,
        [Required][StringLength(20)] string Weight,
        [Required][StringLength(50)] string Category,
        [Required][StringLength(50)] string Abilities,
        [StringLength(300)] string? ImageUrl
    );

    // API'den dönen response modeli
    public record PokemonResponse(
        int Id,
        string Name,
        string Height,
        string Weight,
        string Category,
        string Abilities,
        string? ImageUrl
    );
}
