using PokemonGOAPI.Entities.Arguments.Responses;

namespace PokemonGOAPI.Interfaces.Services
{
    public interface IPokemonStatsService
    {
        PokemonStatsResponse GetPokemonStats(string searchBy, string value);
    }
}
