using AutoMapper;
using MediatR;
using PokedexApi.Application.DTOs;
using PokedexApi.Domain.Interfaces;

namespace PokedexApi.Application.Pokemons.Queries
{
    // MediatR'a giden istek (Request)
    public record GetAllPokemonsQuery : IRequest<List<PokemonResponse>>;

    // İsteği karşılayan işleyici (Handler)
    public class GetAllPokemonsQueryHandler : IRequestHandler<GetAllPokemonsQuery, List<PokemonResponse>>
    {
        private readonly IPokemonRepository _repository;
        private readonly IMapper _mapper;

        public GetAllPokemonsQueryHandler(IPokemonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<PokemonResponse>> Handle(GetAllPokemonsQuery request, CancellationToken cancellationToken)
        {
            var pokemons = await _repository.GetAllAsync();
            return _mapper.Map<List<PokemonResponse>>(pokemons);
        }
    }
}
