using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PokemonGOAPI.Services
{
    public class PokemonMaximumCPService : IPokemonMaximumCPService
    {
        public PokemonMaximumCPResponse GetPokemonMaximumCP()
        {
            var resp = new PokemonMaximumCPResponse();
            var client = new RestClient("https://pokemon-go1.p.rapidapi.com/pokemon_max_cp.json");

            var request = new RestRequest(Method.GET);
            request.BuildDefaultHeaders();

            resp.PokemonMaximumCPList = client.Execute<List<PokemonMaximumCP>>(request).Data;

            if (resp.PokemonMaximumCPList.Count == 0)
            {
                resp.Message = "Nothing returned from the Pokemon Maximum CP list.";
                return resp;
            }

            resp.Success = true;
            resp.Message = "Pokemon Maximum CP list retrieved succesfully!";
            return resp;
        }
    }
}
