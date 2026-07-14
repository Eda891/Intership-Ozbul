using System;
using Microsoft.EntityFrameworkCore;
using Pokedex.Api.Data;
using Pokedex.Api.Dtos;
using Pokedex.Api.Models;
namespace Pokedex.APİ.Endpoints;

public static class PokeEndpoints
{
          
          public static void MapPokeEndpoints(this WebApplication app)
          {
                    var group=app.MapGroup("/Pokedex");

                    //GET /Pokedex
                    group.MapGet("/", async(PokedexContext dbContext)=>
                              await dbContext.Pokes.Include(poke => poke.Category).
                              Select(poke=> new PokeDto(
                                        poke.id,
                                        poke.Name,
                                        poke.Weight,
                                        poke.Height,
                                        poke.Category!.Name,
                                        poke.Abilities
                              ))
                              .AsNoTracking()
                              .ToListAsync()
                    );


                    //GET /Pokedex/1
                    group.MapGet("/{id}", async(int id, PokedexContext dbContext)=>{

                    var poke=await dbContext.Pokes.FindAsync(id);

                    return poke is null?Results.NotFound():Results.Ok(

                    new PokeDetailsDto(
                              poke.id,
                              poke.Name,
                              poke.Weight,
                              poke.Height,
                              poke.CategoryId,
                              poke.Abilities
                    )
                    );
                    }).WithName("GetPoke");



                    //POST /Pokedex
                    group.MapPost("/",async (CreatePokeDto newPoke, PokedexContext dbContext)=>
                    {

                    Poke poke = new()
                    {
                              Name=newPoke.Name,
                              CategoryId=newPoke.CategoryId,
                              Height=newPoke.Height,
                              Weight=newPoke.Weight,
                              Abilities=newPoke.Abilities
                    };

                    dbContext.Pokes.Add(poke);
                    await dbContext.SaveChangesAsync();

                    PokeDetailsDto pokeDto =new PokeDetailsDto(
                              poke.id,
                              poke.Name,
                              poke.Weight,
                              poke.Height,
                              poke.CategoryId,
                              poke.Abilities
                    );

                    return Results.CreatedAtRoute("GetPoke",new {id=pokeDto.id},pokeDto);
                    });



                    //PUT /Pokedex/1
                    group.MapPut("/{id}", async (int id, UpdatePokeDto updatedPoke, PokedexContext dbContext) =>
                    {
                    var existingPoke= await dbContext.Pokes.FindAsync(id);
                    if (existingPoke is null)
                    {
                    return Results.NotFound();
                    }

                    existingPoke.Name=updatedPoke.Name;
                    existingPoke.CategoryId=updatedPoke.CategoryId;
                    existingPoke.Abilities=updatedPoke.Abilities;
                    existingPoke.Height=updatedPoke.Height;
                    existingPoke.Weight=updatedPoke.Weight;

                    await dbContext.SaveChangesAsync();

                    return Results.NoContent();
                    });


                    //DELETE /Pokedex/1
                    group.MapDelete("/{id}", async (int id, PokedexContext dbContext)=>
                    {
                              await dbContext.Pokes.Where(Poke=>Poke.id==id).ExecuteDeleteAsync();
                              
                              return Results.NoContent();
                    });

          }
}