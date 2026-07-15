namespace Pokedex.Api.Models;
//in the POST it is used
public class Poke
{
          public int id {get; set;}
          public required string Name{get; set;}
          public required string Height{get; set;}
          public required string Weight{get; set;}
          public Category? Category{get; set;}
          public int CategoryId {get; set;}
          public required string Abilities{get; set;}
}