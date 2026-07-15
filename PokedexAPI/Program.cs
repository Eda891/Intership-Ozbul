using Pokedex.Api.Data;
using Pokedex.Api.Dtos;
using Pokedex.APİ.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation(); //for the validation controls in update and create Dtos
builder.AddPokedexDb();

var app = builder.Build();


app.MapPokeEndpoints();
app.MapCategoriesEndpoints();

app.MigrateDb();
app.Run();