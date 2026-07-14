namespace Pokedex.Api.Dtos;
public record PokeDto(
          int id,
          string Name,
          string Height,
          string Weight,
          string Category,
          string Abilities        
);
