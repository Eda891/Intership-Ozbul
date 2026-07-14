using Microsoft.EntityFrameworkCore;
using Pokedex.Api.Data;
using Pokedex.Api.Models;

namespace Pokedex.Api.Dtos;

public static class CategoryEndpoints
{
          public static void MapCategoriesEndpoints(this WebApplication app)
          {
                    var group= app.MapGroup("/Category");

                    //GET /Category
                    group.MapGet("/", async (PokedexContext dbContext)=> await dbContext.Category.Select(Category => new CategoryDto(Category.id, Category.Name))
                    .AsNoTracking().ToListAsync()
                    );
          }
}