using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PokemonGOAPI.Services
{
    public class WeatherBoostsService : IWeatherBoostsService
    {
        public WeatherBoostsResponse GetWeatherBoosts()
        {
            var resp = new WeatherBoostsResponse();
            var client = new RestClient("https://pokemon-go1.p.rapidapi.com/weather_boosts.json");

            var request = new RestRequest(Method.GET);
            request.BuildDefaultHeaders();
            resp.WeatherBoosts = client.Execute<Dictionary<string, List<string>>>(request).Data;

            if (resp.WeatherBoosts.Count == 0)
            {
                resp.Message = "Nothing returned from the weather boosts list.";
                return resp;
            }

            resp.Success = true;
            resp.Message = "Weather boosts list retrived successfully.";
            return resp;
        }
    }
}
