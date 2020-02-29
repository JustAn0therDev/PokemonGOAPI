using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PokemonGOAPI.Services
{
    public class PokemonFastMovesService : IPokemonFastMovesService
    {
        public PokemonFastMovesResponse GetPokemonFastMoves()
        {
            var resp = new PokemonFastMovesResponse();
            var client = new RestClient("https://pokemon-go1.p.rapidapi.com/fast_moves.json");

            var request = new RestRequest(Method.GET);
            request.BuildDefaultHeaders();

            resp.PokemonFastMoves = client.Execute<List<PokemonFastMoves>>(request).Data;

            if (resp.PokemonFastMoves.Count == 0)
            {
                resp.Message = "Nothing returned from the Pokemon fast moves list.";
                return resp;
            }

            resp.Success = true;
            resp.Message = "Pokemon fast moves list returned successfully.";
            return resp;
        }
    }
}
