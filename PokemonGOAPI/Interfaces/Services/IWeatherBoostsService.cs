using PokemonGOAPI.Entities.Arguments.Responses;

namespace PokemonGOAPI.Interfaces.Services
{
    public interface IWeatherBoostsService
    {
        WeatherBoostsResponse GetWeatherBoosts();
    }
}
