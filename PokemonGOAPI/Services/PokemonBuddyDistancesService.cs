using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;

using RestSharp;
using System;
using System.Collections.Generic;

namespace PokemonGOAPI.Services
{
    public class PokemonBuddyDistancesService : BaseService, IPokemonBuddyDistancesService
    {
        public override RestClient RestClient {
            get => new RestClient("https://pokemon-go1.p.rapidapi.com/pokemon_buddy_distances.json"); 
        }

        public PokemonBuddyDistancesResponse GetPokemonBuddyDistances(string distanceInKm)
        {
            Dictionary<string, List<PokemonBuddyDistance>> pokemonBuddyDistances = RestClient.Execute<Dictionary<string, List<PokemonBuddyDistance>>>(RestRequest)?.Data;

            if (pokemonBuddyDistances == null || (pokemonBuddyDistances != null && pokemonBuddyDistances.Count == 0))
                return ResponseFactory<PokemonBuddyDistancesResponse>.NothingReturnedFromTheRequestedList();

            if (ArgumentIsValidAndNotEmpty(distanceInKm))
            {
                Dictionary<string, List<PokemonBuddyDistance>> originalListForComparisonAfterFiltering = pokemonBuddyDistances;
                pokemonBuddyDistances = pokemonBuddyDistances.FilterPokemonBuddyDistancesByDistanceInKm(distanceInKm);

                if (pokemonBuddyDistances.GetValueOrDefault(distanceInKm) == null || (pokemonBuddyDistances.Count == originalListForComparisonAfterFiltering.Count || pokemonBuddyDistances.Values.Count == 0))
                    return ResponseFactory<PokemonBuddyDistancesResponse>.ListFilteringDidntWork();

                return ListWasFilteredSuccessfully(pokemonBuddyDistances);
            }

            return ListWasRetrivedSuccessfully(pokemonBuddyDistances);
        }

        private PokemonBuddyDistancesResponse ListWasFilteredSuccessfully(Dictionary<string, List<PokemonBuddyDistance>> pokemonBuddyDistances) 
            => new PokemonBuddyDistancesResponse {
                Success = true,
                Message = "Pokemon buddy distance list filtered successfully.",
                PokemonBuddyDistances = pokemonBuddyDistances
            };

        private PokemonBuddyDistancesResponse ListWasRetrivedSuccessfully(Dictionary<string, List<PokemonBuddyDistance>> pokemonBuddyDistances) 
            => new PokemonBuddyDistancesResponse {
                Success = true,
                Message = "Pokemon buddy distance list retrieved successfully.",
                PokemonBuddyDistances = pokemonBuddyDistances
            };
    }
}
