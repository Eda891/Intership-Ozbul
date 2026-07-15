using AutoMapper;
using MediatR;
using PokedexApi.Application.DTOs;
using PokedexApi.Domain.Interfaces;

namespace PokedexApi.Application.Pokemons.Commands
{
    public record UpdatePokemonCommand(UpdatePokemonRequest Request) : IRequest<bool>;

    public class UpdatePokemonCommandHandler : IRequestHandler<UpdatePokemonCommand, bool>
    {
        private readonly IPokemonRepository _repository;
        private readonly IMapper _mapper;

        public UpdatePokemonCommandHandler(IPokemonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdatePokemonCommand request, CancellationToken cancellationToken)
        {
            // EF Core tracking çakışmalarından kaçınmak için mevcut kaydı önce çekiyoruz
            var existing = await _repository.GetByIdAsync(request.Request.Id);
            if (existing is null)
            {
                return false;
            }

            // Gelen tüm alanları mevcut entity üzerine eşle (yeni alan eklendikçe burayı elle güncellemeye gerek kalmaz)
            _mapper.Map(request.Request, existing);

            await _repository.UpdateAsync(existing);
            return true;
        }
    }
}
