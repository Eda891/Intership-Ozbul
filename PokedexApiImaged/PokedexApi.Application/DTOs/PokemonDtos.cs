using System.ComponentModel.DataAnnotations;

namespace PokedexApi.Application.DTOs
{
    public record PokemonStatsDto(
        [Range(0, 255)] int Hp,
        [Range(0, 255)] int Attack,
        [Range(0, 255)] int Defense,
        [Range(0, 255)] int SpecialAttack,
        [Range(0, 255)] int SpecialDefense,
        [Range(0, 255)] int Speed
    );

    //Input shapes for create (POST) endpoint with validation attributes
    public record CreatePokemonRequest(
        [Required][StringLength(50)] string Name,
        [Required][StringLength(20)] string Height,
        [Required][StringLength(20)] string Weight,
        [Required][StringLength(50)] string Category,
        [Required][StringLength(50)] string Abilities,
        [StringLength(300)] string? ImageUrl,
        [Required][StringLength(50)] string Type,
        [StringLength(100)] string? Weaknesses,
        [StringLength(500)] string? FlavorText,
        [Required] PokemonStatsDto Stats
    );

    //Input shapes for update (PUT) endpoint with validation attributes
    public record UpdatePokemonRequest(
        int Id,
        [Required][StringLength(50)] string Name,
        [Required][StringLength(20)] string Height,
        [Required][StringLength(20)] string Weight,
        [Required][StringLength(50)] string Category,
        [Required][StringLength(50)] string Abilities,
        [StringLength(300)] string? ImageUrl,
        [Required][StringLength(50)] string Type,
        [StringLength(100)] string? Weaknesses,
        [StringLength(500)] string? FlavorText,
        [Required] PokemonStatsDto Stats
    );

    // API'den dönen response modeli
    public record PokemonResponse(
        int Id,
        string Name,
        string Height,
        string Weight,
        string Category,
        string Abilities,
        string? ImageUrl,
        string Type,
        string? Weaknesses,
        string? FlavorText,
        PokemonStatsDto Stats
    );
}