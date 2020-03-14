using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PokemonGOAPI.Services
{
    public class PokemonNameService : IPokemonNameService
    {
        public PokemonNameResponse GetPokemonName()
        {
            var resp = new PokemonNameResponse();
            var client = new RestClient("https://pokemon-go1.p.rapidapi.com/pokemon_names.json");

            var request = new RestRequest(Method.GET);
            request.BuildDefaultHeaders();

            resp.PokemonNames = client.Execute<Dictionary<string, List<PokemonNameObject>>>(request).Data;

            if (resp.PokemonNames != null && resp.PokemonNames.Count == 0)
            {
                resp.Message = "Nothing returned from the Pokemon Name list.";
                return resp;
            }

            resp.Success = true;
            resp.Message = "Pokemon names list retrieved successfully.";
            return resp;
        }
    }
}
