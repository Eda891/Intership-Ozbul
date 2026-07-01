using Pokedex.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

List<PokeDto> Pokedex = [
          new(1,"Lucky"),
          new(2,"Freezer"),
          new(3,"Sleeper")
          ];
          
app.MapGet("/Pokedex",()=>Pokedex);

//GET /Pokedex/1
app.MapGet("/Pokedex/{id}",(int id)=>Pokedex.Find(Poke=>Poke.id==id)).WithName("GetPoke");


//POST /Pokedex
app.MapPost("/Pokedex",(CreatePokeDto newPoke)=>
{
    PokeDto poke=new(
        Pokedex.Count+1,
        newPoke.Name
    );
    Pokedex.Add(poke);

    return Results.CreatedAtRoute("GetPoke",new {id=poke.id},poke);
});

app.Run();