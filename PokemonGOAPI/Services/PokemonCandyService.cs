using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;
using PokemonGOAPI.Utils;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PokemonGOAPI.Services
{
    public class PokemonCandyService : BaseService, IPokemonCandyService
    {
        public override RestClient RestClient {
            get => new RestClient("https://pokemon-go1.p.rapidapi.com/pokemon_candy_to_evolve.json");
        }
        public PokemonCandyResponse GetPokemonCandy(string numberOfCandies)
        {
            Dictionary<string, List<PokemonCandy>> allPokemonCandy = new Dictionary<string, List<PokemonCandy>>();
            allPokemonCandy = RestClient.Execute<Dictionary<string, List<PokemonCandy>>>(RestRequest)?.Data;

            if (allPokemonCandy == null || (allPokemonCandy != null && allPokemonCandy.Count == 0))
                return ResponseFactory<PokemonCandyResponse>.NothingReturnedFromTheRequestedList();

            if (NumberOfCandiesWasProvided(numberOfCandies))
            {
                Dictionary<string, List<PokemonCandy>> originalListForComparisonAfterFiltering = allPokemonCandy;
                allPokemonCandy = allPokemonCandy.FilterPokemonListByNumberOfCandiesAndGroupByPokemonId(numberOfCandies);

                if (allPokemonCandy.Count == originalListForComparisonAfterFiltering.Count || allPokemonCandy.Count == 0)
                    return ResponseFactory<PokemonCandyResponse>.ListFilteringDidntWork();

                return ListWasFilteredSuccessfully(allPokemonCandy);
            }
            return ListWasRetrivedSuccessfully(allPokemonCandy);
        }

        private bool NumberOfCandiesWasProvided(string numberOfCandies) => !string.IsNullOrEmpty(numberOfCandies);

        private PokemonCandyResponse ListWasFilteredSuccessfully(Dictionary<string, List<PokemonCandy>> allPokemonCandy) 
            => new PokemonCandyResponse {
                Success = true,
                Message = $"List of pokemon candy retrieved successfully.",
                AllPokemonCandy = allPokemonCandy
            };

        private PokemonCandyResponse ListWasRetrivedSuccessfully(Dictionary<string, List<PokemonCandy>> allPokemonCandy) 
            => new PokemonCandyResponse {
                Success = true,
                Message = "List of pokemon candy retrieved successfully.",
                AllPokemonCandy = allPokemonCandy
            };
    }
}
