using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PokemonGOAPI.Services
{
    public class PokemonNameService : BaseService, IPokemonNameService
    {
        public override RestClient RestClient { 
            get => new RestClient("https://pokemon-go1.p.rapidapi.com/pokemon_names.json"); 
        }

        public PokemonNameResponse GetPokemonName()
        {
            Dictionary<string, List<PokemonNameObject>> pokemonNameDictionary = RestClient.Execute<Dictionary<string, List<PokemonNameObject>>>(RestRequest)?.Data;

            if (pokemonNameDictionary != null && pokemonNameDictionary.Count == 0)
                return ResponseFactory<PokemonNameResponse>.NothingReturnedFromTheRequestedList();

            return ListWasRetrievedSuccessfully(pokemonNameDictionary);
        }

        private PokemonNameResponse ListWasRetrievedSuccessfully(Dictionary<string, List<PokemonNameObject>> pokemonNameDictionary) 
            => new PokemonNameResponse {
            Success = true,
            Message = "Pokemon names list retrieved successfully.",
            PokemonNames = pokemonNameDictionary
            };
    }
}