using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PokemonGOAPI.Services
{
    public class PokemonStatsService : IPokemonStatsService
    {
        public PokemonStatsResponse GetPokemonStats(string searchBy, string value)
        {
            var parameterCheck = PokemonUtils.CheckSearchByAndValue(searchBy, value);
            if (parameterCheck != null)
                return null;

            var response = new PokemonStatsResponse();

            if ((string.IsNullOrEmpty(searchBy) && !string.IsNullOrEmpty(value)) || (!string.IsNullOrEmpty(searchBy) && string.IsNullOrEmpty(value)))
            {
                response.Message = "Cannot filter a pokemon stat without both required values.";
                return response;
            }

            var client = new RestClient("https://pokemon-go1.p.rapidapi.com/pokemon_stats.json");
            var request = new RestRequest(Method.GET);
            request.BuildDefaultHeaders();

            response.PokemonData = client.Execute<List<PokemonData>>(request).Data;

            if (response.PokemonData != null && response.PokemonData.Count == 0)
            {
                response.Message = "Nothing returned from the Pokemon Stats list.";
                return response;
            }

            if (!string.IsNullOrEmpty(searchBy))
            {
                List<PokemonData> originalList = response.PokemonData;
                response.PokemonData = response.PokemonData.FilterPokemonList(searchBy, value);
                if (response.PokemonData.Count == originalList.Count || response.PokemonData.Count == 0)
                {
                    response.Message = "No filter could be made by using the provided parameters. Did you mean to send something else?";
                    response.PokemonData = null;
                    return response;
                }
                response.Success = true;
                response.Message = "Pokemon Stats list filtered successfully.";
                return response;
            }

            response.Success = true;
            response.Message = "API request made and data returned successfully.";
            return response;
        }
    }
}
