using System;
using System.Collections.Generic;
using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;
using PokemonGOAPI.Utils;
using RestSharp;

namespace PokemonGOAPI.Services
{
    public class PokemonStatsService : BaseService, IPokemonStatsService
    {
        public override RestClient RestClient { 
            get => new RestClient("https://pokemon-go1.p.rapidapi.com/pokemon_stats.json"); 
        }

        public PokemonStatsResponse GetPokemonStats(string searchBy, string value)
        {
            List<PokemonData> pokemonData = null;

            if (ReceivedArgumentsAreNotValid(searchBy, value))
                return ResponseFactory<PokemonStatsResponse>.BothRequiredValuesForFilteringWereNotProvided();

            pokemonData = RestClient.Execute<List<PokemonData>>(RestRequest)?.Data;

            if (pokemonData == null || (pokemonData != null && pokemonData.Count == 0))
                return ResponseFactory<PokemonStatsResponse>.NothingReturnedFromTheRequestedList();

            if (!string.IsNullOrEmpty(searchBy))
            {
                List<PokemonData> originalListForComparisonAfterFiltering = pokemonData;
                pokemonData = pokemonData.FilterPokemonList(searchBy, value);
                
                if (pokemonData.Count == originalListForComparisonAfterFiltering.Count || pokemonData.Count == 0)
                    return ResponseFactory<PokemonStatsResponse>.ListFilteringDidntWork();

                return ListWasFilteredSuccessfully(pokemonData);
            }

            return ListWasRetrievedSuccessfully(pokemonData);
        }

        private PokemonStatsResponse ListWasFilteredSuccessfully(List<PokemonData> pokemonData)
            => new PokemonStatsResponse {
                Success = true,
                Message = "Pokemon stats list filtered successfully.",
                PokemonData = pokemonData
            };

        private PokemonStatsResponse ListWasRetrievedSuccessfully(List<PokemonData> pokemonData)
            => new PokemonStatsResponse {
                Success = true,
                Message = "Pokemon stats list retrived successfully.",
                PokemonData = pokemonData
            };
    }
}
