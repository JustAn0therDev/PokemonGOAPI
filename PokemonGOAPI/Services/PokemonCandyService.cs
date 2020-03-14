using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonGOAPI.Services
{
    public class PokemonCandyService : IPokemonCandyService
    {
        public PokemonCandyResponse GetPokemonCandy(string numberOfCandies)
        {
            var result = new PokemonCandyResponse();
            var client = new RestClient("https://pokemon-go1.p.rapidapi.com/pokemon_candy_to_evolve.json");

            var request = new RestRequest();
            request.BuildDefaultHeaders();

            result.AllPokemonCandy = client.Execute<Dictionary<string, List<PokemonCandy>>>(request).Data;

            if (result.AllPokemonCandy != null && result.AllPokemonCandy.Count == 0)
            {
                result.Message = "Nothing returned from the Pokemon Candy list.";
                return result;
            }

            if (!string.IsNullOrEmpty(numberOfCandies))
            {
                Dictionary<string, List<PokemonCandy>> originalList = result.AllPokemonCandy;
                result.AllPokemonCandy = result.AllPokemonCandy.FilterPokemonListByNumberOfCandiesAndGroupByPokemonId(numberOfCandies);

                if (result.AllPokemonCandy.Count == originalList.Count || result.AllPokemonCandy.Count == 0)
                {
                    result.Message = "A filter using the sent parameters could not be made, did you mean to send something else?";
                    result.AllPokemonCandy = null;
                    return result;
                }
                result.Success = true;
                result.Message = $"List of Pokemon that need {numberOfCandies} candies to evolve retrieved successfully!";
                return result;
            }

            result.Success = true;
            result.Message = "Pokemon Candy list returned successfully.";
            return result;
        }
    }
}
