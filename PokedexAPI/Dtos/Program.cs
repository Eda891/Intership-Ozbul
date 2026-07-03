using Pokedex.Api.Dtos;
using Pokedex.APİ.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();
var app = builder.Build();

app.MapPokeEndpoints();
app.Run();