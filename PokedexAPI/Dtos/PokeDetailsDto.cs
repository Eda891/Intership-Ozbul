namespace Pokedex.Api.Dtos;
public record PokeDetailsDto(
          int id,
          string Name,
          string Height,
          string Weight,
          int CategoryId,
          string Abilities
);
