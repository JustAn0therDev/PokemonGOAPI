using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PokemonGOAPI.Services
{
    public class NestingPokemonService : INestingPokemonService
    {
        public NestingPokemonResponse GetNestingPokemon()
        {
            var resp = new NestingPokemonResponse();
            var client = new RestClient("https://pokemon-go1.p.rapidapi.com/nesting_pokemon.json");

            var request = new RestRequest(Method.GET);
            request.BuildDefaultHeaders();

            resp.NestingPokemon = client.Execute<Dictionary<string, List<NestingPokemon>>>(request).Data;

            if (resp.NestingPokemon != null && resp.NestingPokemon.Values.Count == 0)
            {
                resp.Message = "Nothing was found in the request nesting pokemon list.";
                return resp;
            }

            resp.Success = true;
            resp.Message = "Nesting pokemon list found succesfully.";
            return resp;
        }
    }
}
