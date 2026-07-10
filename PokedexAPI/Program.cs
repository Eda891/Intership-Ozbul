using Pokedex.Api.Data;
using Pokedex.APİ.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();
builder.AddPokedexDb();

var app = builder.Build();

app.MigrateDb();

app.MapPokeEndpoints();
app.Run();