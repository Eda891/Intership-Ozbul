using PokedexApi.Application;
using PokedexApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
//registers services, enables Swagger, starts the app.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // C#'taki string / string? farkını Swagger şemasına yansıt
    // (bu olmadan tüm reference type'lar "nullable: true" görünür)
    options.SupportNonNullableReferenceTypes();
    options.UseAllOfToExtendReferenceSchemas();
});

// Application ve Infrastructure katmanlarındaki servisleri kaydet
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();