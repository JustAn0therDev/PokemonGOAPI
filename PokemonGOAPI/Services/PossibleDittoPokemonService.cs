using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PokemonGOAPI.Services
{
    public class PossibleDittoPokemonService : IPossibleDittoPokemonService
    {
        public PossibleDittoPokemonResponse GetPossibleDittoPokemon()
        {
            var resp = new PossibleDittoPokemonResponse();
            var client = new RestClient("https://pokemon-go1.p.rapidapi.com/possible_ditto_pokemon.json");

            var request = new RestRequest(Method.GET);
            request.BuildDefaultHeaders();

            resp.PossibleDittoPokemon = client.Execute<Dictionary<string, List<PokemonNameObject>>>(request).Data;

            if (resp.PossibleDittoPokemon != null && resp.PossibleDittoPokemon.Count == 0)
            {
                resp.Message = "Nothing returned from the Possible Ditto Pokemon list.";
                return resp;
            }

            resp.Success = true;
            resp.Message = "Possible Ditto Pokemon list retrieved successfully";
            return resp;
        }
    }
}
