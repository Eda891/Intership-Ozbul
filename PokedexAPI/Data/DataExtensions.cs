using Microsoft.EntityFrameworkCore;

namespace Pokedex.Api.Data;
using Pokedex.Api.Models;
//this has the starter categories
//if the table's empty; MigrateDb() applies pending EF migrations on startup so the DB schema stays in sync.

public static class DataExtensions
{
          public static void MigrateDb(this WebApplication app)
          {
                    using var scope= app.Services.CreateScope();
                    var dbContext= scope.ServiceProvider.GetRequiredService<PokedexContext>();
                    dbContext.Database.Migrate();
          }

          public static void AddPokedexDb (this WebApplicationBuilder builder)
          {
                    var connString= builder.Configuration.GetConnectionString("Pokedex");
                    // builder.Services.AddScoped<PokedexContext>
                    builder.Services.AddSqlite<PokedexContext>(
                    connString,
                    optionsAction: options => options.UseSeeding((context,_)=>
                    {
                              if(!context.Set<Category>().Any())
                              {
                                        context.Set<Category>().AddRange(
                                                  new Category {Name="Seed"},
                                                  new Category {Name="Lizard"},
                                                  new Category {Name="Flame"},
                                                  new Category {Name="Bird"},
                                                  new Category {Name="Shell"}
                                        );

                                        context.SaveChanges();
                              }
                    })
                    
                    );         
          }
}
