using PokemonGOAPI.Entities.Arguments.Responses;

namespace PokemonGOAPI.Interfaces.Services
{
    public interface IChargedPokemonMovesService
    {
        ChargedPokemonMovesResponse GetChargedPokemonMoves(string searchBy, string value); 
    }
}
