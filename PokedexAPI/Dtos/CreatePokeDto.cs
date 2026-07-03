using System.ComponentModel.DataAnnotations;

namespace Pokedex.Api.Dtos;

public record CreatePokeDto(
          [Required][StringLength(50)]string Name,
          [Required][StringLength(20)]string Height,
          [Required][StringLength(20)]string Weight,
          [Required][StringLength(50)]string Category,
          [Required][StringLength(50)]string Abilities
);