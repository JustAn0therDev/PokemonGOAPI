using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;
using PokemonGOAPI.Utils;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PokemonGOAPI.Services
{
    public class PokemonEncounterService : BaseService, IPokemonEncounterService
    {
        public override RestClient RestClient {
            get => new RestClient("https://pokemon-go1.p.rapidapi.com/pokemon_encounter_data.json"); 
        }

        public PokemonEncounterResponse GetPokemonEncounter(string searchBy, string value)
        {
            List<PokemonEncounter> pokemonEncounters = null;

            if (ReceivedArgumentsAreNotValid(searchBy, value))
                return ResponseFactory<PokemonEncounterResponse>.BothRequiredValuesForFilteringWereNotProvided();

            pokemonEncounters = RestClient.Execute<List<PokemonEncounter>>(RestRequest)?.Data;

            if (pokemonEncounters == null || (pokemonEncounters != null && pokemonEncounters.Count == 0))
                return ResponseFactory<PokemonEncounterResponse>.NothingReturnedFromTheRequestedList();

            if (ArgumentsAreValidAndNotEmpty(searchBy, value))
            {
                List<PokemonEncounter> originalListForComparisonAfterFiltering = pokemonEncounters;
                pokemonEncounters = pokemonEncounters.FilterPokemonEncountersList(searchBy, value);

                if (pokemonEncounters == null || (pokemonEncounters.Count == originalListForComparisonAfterFiltering.Count || pokemonEncounters.Count == 0))
                    return ResponseFactory<PokemonEncounterResponse>.ListFilteringDidntWork();
                
                return ListWasFilteredSuccessfully(pokemonEncounters);
            }
            return ListWasRetrivedSuccessfully(pokemonEncounters);
        }

        private PokemonEncounterResponse ListWasFilteredSuccessfully(List<PokemonEncounter> pokemonEncounters) 
            => new PokemonEncounterResponse {
                    Success = true,
                    Message = "Pokemon encounters list filtered successfully.",
                    PokemonEncounters = pokemonEncounters
                };

        private PokemonEncounterResponse ListWasRetrivedSuccessfully(List<PokemonEncounter> pokemonEncounters) 
            => new PokemonEncounterResponse {
                    Success = true,
                    Message = "Pokemon encounters list retrieved successfully.",
                    PokemonEncounters = pokemonEncounters
                };
    }
}
