using System;
using Pokedex.Api.Data;
using Pokedex.Api.Dtos;
using Pokedex.Api.Models;
namespace Pokedex.APİ.Endpoints;

public static class PokeEndpoints
{
          private static readonly List<PokeDto> Pokedex = [
          new(1,"Bulbasaur","2' 04","15.2 lbs","Seed","Overgrow"),
          new(2,"Venusaur","6' 07","220.5 lbs","Seed","Overgrow"),
          new(3,"Charmander","2' 00","18.7 lbs","Lizard","Blaze")
          ];

          public static void MapPokeEndpoints(this WebApplication app)
          {
                    var group=app.MapGroup("/Pokedex");

                    //GET /Pokedex
                    group.MapGet("/",()=>Pokedex);


                    //GET /Pokedex/1
                    group.MapGet("/Pokedex/{id}",(int id)=>{
                    var Poke=Pokedex.Find(Poke=>Poke.id==id);
                    return Poke is null?Results.NotFound():Results.Ok(Poke);
                    }).WithName("GetPoke");



                    //POST /Pokedex
                    group.MapPost("/",(CreatePokeDto newPoke, PokedexContext dbContext)=>
                    {

                    Poke poke = new()
                    {
                              Name=newPoke.Name,
                              Categoryİd=newPoke.CategoryId,
                              Height=newPoke.Height,
                              Weight=newPoke.Weight,
                              Abilities=newPoke.Abilities
                    };
                    // PokeDto poke=new(
                    //           Pokedex.Count+1,
                    //           newPoke.Name,
                    //           newPoke.Height,
                    //           newPoke.Weight,
                    //           newPoke.Category,
                    //           newPoke.Abilities
                    // );
                    // Pokedex.Add(poke);

                    dbContext.Pokes.Add(poke);
                    dbContext.SaveChanges();
                    
                    return Results.CreatedAtRoute("GetPoke",new {id=poke.id},poke);
                    });



                    //PUT /Pokedex/1
                    group.MapPut("/{id}", (int id, UpdatePokeDto updatedPoke) =>
                    {
                    var index=Pokedex.FindIndex(Poke=>Poke.id==id);

                    if (index == -1)
                    {
                    return Results.NotFound();
                    }

                    Pokedex[index]=new PokeDto(
                    id,
                    updatedPoke.Name,
                    updatedPoke.Height,
                    updatedPoke.Weight,
                    updatedPoke.Category,
                    updatedPoke.Abilities
                    );

                    return Results.NoContent();
                    });


                    //DELETE /Pokedex/1
                    group.MapDelete("/{id}", (int id)=>
                    {
                    Pokedex.RemoveAll(poke=>poke.id==id);

                    return Results.NoContent();
                    });

          }
}