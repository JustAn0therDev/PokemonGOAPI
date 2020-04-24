using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;
using PokemonGOAPI.Utils;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PokemonGOAPI.Services
{
    public class NestingPokemonService : BaseService, INestingPokemonService
    {
        public override RestClient RestClient { 
            get { 
                return new RestClient("https://pokemon-go1.p.rapidapi.com/nesting_pokemon.json"); 
            }
        }

        public NestingPokemonResponse GetNestingPokemon()
        {
            Dictionary<string, List<NestingPokemon>> nestingPokemon = RestClient.Execute<Dictionary<string, List<NestingPokemon>>>(RestRequest)?.Data;

            if (nestingPokemon == null || (nestingPokemon != null && nestingPokemon.Values.Count == 0))
                return ResponseFactory<NestingPokemonResponse>.NothingReturnedFromTheRequestedList();

            return NestingPokemonListRetrievedSuccesfully(nestingPokemon);
        }

        private NestingPokemonResponse NestingPokemonListRetrievedSuccesfully(Dictionary<string, List<NestingPokemon>> nestingPokemon) {
            return new NestingPokemonResponse {
                Success = true,
                Message = "Nesting pokemon list found successfully.",
                NestingPokemon = nestingPokemon
            };
        }
    }
}
