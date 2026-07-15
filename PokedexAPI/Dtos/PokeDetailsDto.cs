namespace Pokedex.Api.Dtos;
//used for  get-by-id, create (POST) endpoints
public record PokeDetailsDto(
          int id,
          string Name,
          string Height,
          string Weight,
          int CategoryId,
          string Abilities
);
