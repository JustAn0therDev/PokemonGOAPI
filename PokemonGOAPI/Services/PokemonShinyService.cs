using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PokemonGOAPI.Services
{
    public class PokemonShinyService : IPokemonShinyService
    {
        public PokemonShinyResponse GetPokemonShiny()
        {
            var resp = new PokemonShinyResponse();
            var client = new RestClient("https://pokemon-go1.p.rapidapi.com/shiny_pokemon.json");

            var request = new RestRequest(Method.GET);
            request.BuildDefaultHeaders();

            resp.PokemonShinyList = client.Execute<Dictionary<string, List<PokemonShiny>>>(request).Data;

            if (resp.PokemonShinyList != null && resp.PokemonShinyList.Count == 0)
            {
                resp.Message = "Nothing returned from the Pokemon Shiny list.";
                return resp;
            }

            resp.Success = true;
            resp.Message = "Pokemon Shiny list returned successfully.";
            return resp;
        }
    }
}
