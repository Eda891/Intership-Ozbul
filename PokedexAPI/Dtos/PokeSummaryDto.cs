namespace Pokedex.Api.Dtos;
public record PokeSummaryDto(
          int id,
          string Name,
          string Height,
          string Weight,
          string Category,
          string Abilities        
);
