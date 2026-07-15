using AutoMapper;
using MediatR;
using PokedexApi.Application.DTOs;
using PokedexApi.Domain.Interfaces;

namespace PokedexApi.Application.Pokemons.Queries
{
    //fetches a single record by id. second GET
    public record GetPokemonByIdQuery(int Id) : IRequest<PokemonResponse?>;

    public class GetPokemonByIdQueryHandler : IRequestHandler<GetPokemonByIdQuery, PokemonResponse?>
    {
        private readonly IPokemonRepository _repository;
        private readonly IMapper _mapper;

        public GetPokemonByIdQueryHandler(IPokemonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PokemonResponse?> Handle(GetPokemonByIdQuery request, CancellationToken cancellationToken)
        {
            var pokemon = await _repository.GetByIdAsync(request.Id);
            return pokemon is null ? null : _mapper.Map<PokemonResponse>(pokemon);
        }
    }
}
