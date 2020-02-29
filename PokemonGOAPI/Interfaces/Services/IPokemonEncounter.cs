using PokemonGOAPI.Entities.Arguments.Responses;

namespace PokemonGOAPI.Interfaces.Services
{
    public interface IPokemonEncounterService
    {
        PokemonEncounterResponse GetPokemonEncounter(string searchBy, string value);
    }
}
