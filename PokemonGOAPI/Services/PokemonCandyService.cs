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
            Dictionary<string, List<PokemonCandy>> allPokemonCandyDictionary = RestClient.Execute<Dictionary<string, List<PokemonCandy>>>(RestRequest)?.Data;

            if (allPokemonCandyDictionary == null || (allPokemonCandyDictionary != null && allPokemonCandyDictionary.Count == 0))
                return ResponseFactory<PokemonCandyResponse>.NothingReturnedFromTheRequestedList();

            if (ArgumentIsValidAndNotEmpty(numberOfCandies))
            {
                Dictionary<string, List<PokemonCandy>> originalListForComparisonAfterFiltering = allPokemonCandyDictionary;
                allPokemonCandyDictionary = allPokemonCandyDictionary.FilterPokemonListByNumberOfCandiesAndGroupByPokemonId(numberOfCandies);

                if (allPokemonCandyDictionary.GetValueOrDefault(numberOfCandies) == null
                    || (allPokemonCandyDictionary.Count == originalListForComparisonAfterFiltering.Count || allPokemonCandyDictionary.Count == 0)
                    )
                    return ResponseFactory<PokemonCandyResponse>.ListFilteringDidntWork();

                return ListWasFilteredSuccessfully(allPokemonCandyDictionary);
            }
            return ListWasRetrivedSuccessfully(allPokemonCandyDictionary);
        }

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
