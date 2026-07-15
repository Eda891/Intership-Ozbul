using AutoMapper;
using PokedexApi.Application.DTOs;
using PokedexApi.Domain.Entities;

namespace PokedexApi.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pokemon, PokemonResponse>();
            CreateMap<CreatePokemonRequest, Pokemon>();
            CreateMap<UpdatePokemonRequest, Pokemon>();
        }
    }
}
