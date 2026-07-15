namespace Pokedex.Api.Dtos;
//Used for the list endpoint. first GET.
public record PokeSummaryDto(
          int id,
          string Name,
          string Height,
          string Weight,
          string Category,
          string Abilities        
);
