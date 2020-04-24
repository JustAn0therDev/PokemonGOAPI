using PokemonGOAPI.Entities.Arguments.Responses;

namespace PokemonGOAPI.Interfaces.Services
{
    public interface IChargedPokemonMovesService : IService
    {
        ChargedPokemonMovesResponse GetChargedPokemonMoves(string searchBy, string value); 
    }
}
