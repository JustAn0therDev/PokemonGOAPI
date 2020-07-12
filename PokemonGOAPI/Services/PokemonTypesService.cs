using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonGOAPI.Services
{
    public class PokemonTypesService : BaseService, IPokemonTypesService
    {
        public override RestClient RestClient {
            get => new RestClient("https://pokemon-go1.p.rapidapi.com/pokemon_types.json");
        }

        public PokemonTypesResponse GetPokemonTypes(string pokemonName)
        {
            List<PokemonType> pokemonTypes = RestClient.Execute<List<PokemonType>>(RestRequest)?.Data;

            if (pokemonTypes == null || (pokemonTypes != null && pokemonTypes.Count == 0))
                return ResponseFactory<PokemonTypesResponse>.NothingReturnedFromTheRequestedList();

            if (ArgumentIsValidAndNotEmpty(pokemonName))
            {
                List<PokemonType> originalListForComparisonAfterFiltering = pokemonTypes;
                pokemonTypes = FilterPokemonTypes(pokemonTypes, pokemonName);

                if (pokemonTypes.Count == originalListForComparisonAfterFiltering.Count || pokemonTypes.Count == 0)
                    return ResponseFactory<PokemonTypesResponse>.ListFilteringDidntWork();

                return ListWasFilteredSuccessfully(pokemonTypes);
            }
            return ListWasRetrievedSuccessfully(pokemonTypes);
        }

        private List<PokemonType> FilterPokemonTypes(List<PokemonType> pokemonTypes, string pokemonName) 
            => pokemonTypes.Where(w => w.PokemonName.ToLower() == pokemonName.ToLower()).ToList();

        private PokemonTypesResponse ListWasFilteredSuccessfully(List<PokemonType> pokemonTypes) 
            => new PokemonTypesResponse {
                Success = true,
                Message = "List of pokemon type filtered successfully",
                PokemonTypes = pokemonTypes
            };

        private PokemonTypesResponse ListWasRetrievedSuccessfully(List<PokemonType> pokemonTypes) 
            => new PokemonTypesResponse {
                Success = true,
                Message = "List of pokemon type retrieved successfully",
                PokemonTypes = pokemonTypes
            };
    }
}
