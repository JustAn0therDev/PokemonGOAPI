using PokemonGOAPI.Entities.Arguments.Responses;

namespace PokemonGOAPI.Interfaces.Services
{
    public interface IPokemonCandyService
    {
        PokemonCandyResponse GetPokemonCandy(string numberOfCandies);
    }
}
