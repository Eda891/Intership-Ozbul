using Microsoft.EntityFrameworkCore;
using Pokedex.Api.Models;

namespace Pokedex.Api.Data;
//my DbContext
public class PokedexContext(DbContextOptions<PokedexContext> options)
:DbContext(options)
{
          public DbSet<Poke>Pokes => Set<Poke>();

          public DbSet<Category>Category => Set<Category>();


}