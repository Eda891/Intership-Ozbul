using Microsoft.AspNetCore.Mvc;
using PokedexApi.Application.DTOs;
using PokedexApi.Application.Pokemons.Commands;
using PokedexApi.Application.Pokemons.Queries;

namespace PokedexApi.API.Controllers
{
    //The HTTP endpoints.
    //Each one sends the matching Command/Query through Mediator.
    public class PokemonController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllPokemonsQuery());
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await Mediator.Send(new GetPokemonByIdQuery(id));
            return result is null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePokemonRequest request)
        {
            var result = await Mediator.Send(new CreatePokemonCommand(request));
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePokemonRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest("Route id ile body id eşleşmiyor.");
            }

            var success = await Mediator.Send(new UpdatePokemonCommand(request));
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await Mediator.Send(new DeletePokemonCommand(id));
            return success ? NoContent() : NotFound();
        }
    }
}
