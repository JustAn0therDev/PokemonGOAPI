using PokemonGOAPI.Entities.Arguments.Responses;

namespace PokemonGOAPI.Interfaces.Services
{
    public interface IPokemonTypesService
    {
        PokemonTypesResponse GetPokemonTypes(string pokemonName);
    }
}
