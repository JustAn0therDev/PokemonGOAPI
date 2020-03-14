using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PokemonGOAPI.Services
{
    public class ReleasedPokemonService : IReleasedPokemonService
    {
        public ReleasedPokemonResponse GetReleasedPokemonResponse()
        {
            var resp = new ReleasedPokemonResponse();

            var client = new RestClient("https://pokemon-go1.p.rapidapi.com/released_pokemon.json");
            var request = new RestRequest(Method.GET);
            request.BuildDefaultHeaders();

            resp.ReleasedPokemon = client.Execute<Dictionary<string, List<PokemonNameObject>>>(request).Data;

            if (resp.ReleasedPokemon != null && resp.ReleasedPokemon.Count == 0)
            {
                resp.Message = "Nothing returned from the released pokemon list.";
                return resp;
            }

            resp.Success = true;
            resp.Message = "Released pokemon list returned successfully.";
            return resp;
        }
    }
}
