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
app.MapGet("/Pokedex/{id}",(int id)=>{
    var Poke=Pokedex.Find(Poke=>Poke.id==id);
    return Poke is null?Results.NotFound():Results.Ok(Poke);
}).WithName("GetPoke");


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


//PUT /Pokedex/1
app.MapPut("/Pokedex/{id}", (int id, UpdatePokeDto updatedPoke) =>
{
    var index=Pokedex.FindIndex(Poke=>Poke.id==id);

    if (index == -1)
    {
        return Results.NotFound();
    }

    Pokedex[index]=new PokeDto(
        id,
        updatedPoke.Name
    );

    return Results.NoContent();
});


//DELETE /Pokedex/1
app.MapDelete("/Pokedex/{id}", (int id)=>
{
    Pokedex.RemoveAll(poke=>poke.id==id);

    return Results.NoContent();
});

app.Run();