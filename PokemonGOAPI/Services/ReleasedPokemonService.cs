using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;

using RestSharp;
using System;
using System.Collections.Generic;

namespace PokemonGOAPI.Services
{
    public class ReleasedPokemonService : BaseService, IReleasedPokemonService
    {
        public override RestClient RestClient {
            get => new RestClient("https://pokemon-go1.p.rapidapi.com/released_pokemon.json");
        }

        public ReleasedPokemonResponse GetReleasedPokemonResponse()
        {
            Dictionary<string, List<PokemonNameObject>> releasedPokemonDictionary = RestClient.Execute<Dictionary<string, List<PokemonNameObject>>>(RestRequest)?.Data;

            if (releasedPokemonDictionary != null && releasedPokemonDictionary.Count == 0)
                return ResponseFactory<ReleasedPokemonResponse>.NothingReturnedFromTheRequestedList();

            return ListWasRetrievedSuccessfully(releasedPokemonDictionary);
        }

        private ReleasedPokemonResponse ListWasRetrievedSuccessfully(Dictionary<string, List<PokemonNameObject>> releasedPokemonDictionary) 
            => new ReleasedPokemonResponse {
                Success = true,
                Message = "Released Pokemon list retrieved successfully.",
                ReleasedPokemon = releasedPokemonDictionary
            };
    }
}
