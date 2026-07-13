using Pokedex.Api.Data;
using Pokedex.Api.Dtos;
using Pokedex.APİ.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();
builder.AddPokedexDb();

var app = builder.Build();


app.MapPokeEndpoints();
app.MapCategoriesEndpoints();

app.MigrateDb();
app.Run();