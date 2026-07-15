using System.ComponentModel.DataAnnotations;

namespace PokedexApi.Application.DTOs
{
    //Input shapes for create (POST) endpoint with validation attributes
    public record CreatePokemonRequest(
        [Required][StringLength(50)] string Name,
        [Required][StringLength(20)] string Height,
        [Required][StringLength(20)] string Weight,
        [Required][StringLength(50)] string Category,
        [Required][StringLength(50)] string Abilities,
        [StringLength(300)] string? ImageUrl
    );

    //Input shapes for update (PUT) endpoint with validation attributes
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
