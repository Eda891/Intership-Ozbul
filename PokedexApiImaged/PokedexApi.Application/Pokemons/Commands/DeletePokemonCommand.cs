using MediatR;
using PokedexApi.Domain.Interfaces;

namespace PokedexApi.Application.Pokemons.Commands
{
    //updates an existing record. PUT
    public record DeletePokemonCommand(int Id) : IRequest<bool>;

    public class DeletePokemonCommandHandler : IRequestHandler<DeletePokemonCommand, bool>
    {
        private readonly IPokemonRepository _repository;

        public DeletePokemonCommandHandler(IPokemonRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeletePokemonCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repository.GetByIdAsync(request.Id);
            if (existing is null)
            {
                return false;
            }

            await _repository.DeleteAsync(request.Id);
            return true;
        }
    }
}
