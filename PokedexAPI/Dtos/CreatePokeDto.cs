using System.ComponentModel.DataAnnotations;
//Input shapes for create (POST) endpoint with validation attributes
namespace Pokedex.Api.Dtos;
public record CreatePokeDto(
          [Required][StringLength(50)]string Name,
          [Required][StringLength(20)]string Height,
          [Required][StringLength(20)]string Weight,
          [Required][Range(1,50)]int  CategoryId,
          [Required][StringLength(50)]string Abilities
);