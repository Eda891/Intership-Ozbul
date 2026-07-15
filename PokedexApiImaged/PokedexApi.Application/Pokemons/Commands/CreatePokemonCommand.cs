using AutoMapper;
using MediatR;
using PokedexApi.Application.DTOs;
using PokedexApi.Domain.Entities;
using PokedexApi.Domain.Interfaces;

namespace PokedexApi.Application.Pokemons.Commands
{
    //adds a new record POST
    public record CreatePokemonCommand(CreatePokemonRequest Request) : IRequest<PokemonResponse>;

    public class CreatePokemonCommandHandler : IRequestHandler<CreatePokemonCommand, PokemonResponse>
    {
        private readonly IPokemonRepository _repository;
        private readonly IMapper _mapper;

        public CreatePokemonCommandHandler(IPokemonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PokemonResponse> Handle(CreatePokemonCommand request, CancellationToken cancellationToken)
        {
            // Request modelinden Domain entity'sine dönüşüm
            var pokemon = _mapper.Map<Pokemon>(request.Request);

            var created = await _repository.CreateAsync(pokemon);

            // Domain entity'sinden response modeline geri dönüşüm
            return _mapper.Map<PokemonResponse>(created);
        }
    }
}
