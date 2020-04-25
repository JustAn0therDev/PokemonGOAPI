using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;
using PokemonGOAPI.Utils;
using RestSharp;
using System.Collections.Generic;

namespace PokemonGOAPI.Services
{
    public class WeatherBoostsService : BaseService, IWeatherBoostsService
    {
        public override RestClient RestClient {
            get => new RestClient("https://pokemon-go1.p.rapidapi.com/weather_boosts.json");
        }

        public WeatherBoostsResponse GetWeatherBoosts()
        {
            Dictionary<string, List<string>> weatherBoostsDictionary = RestClient.Execute<Dictionary<string, List<string>>>(RestRequest)?.Data;

            if ( weatherBoostsDictionary == null || (weatherBoostsDictionary != null && weatherBoostsDictionary.Count == 0))
                return ResponseFactory<WeatherBoostsResponse>.NothingReturnedFromTheRequestedList();

            return ListWasRetrievedSuccessfully(weatherBoostsDictionary);
        }
        
        private WeatherBoostsResponse ListWasRetrievedSuccessfully(Dictionary<string, List<string>> weatherBoostsDictionary) 
            => new WeatherBoostsResponse {
                Success = true,
                Message = "Weather boosts list retrieved successfully.",
                WeatherBoosts = weatherBoostsDictionary
            };
    }
}
