using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PokemonGOAPI.Services
{
    public class ChargedPokemonMovesService : IChargedPokemonMovesService
    {
        public ChargedPokemonMovesResponse GetChargedPokemonMoves(string searchBy, string value)
        {
            var resp = new ChargedPokemonMovesResponse();
            var checkParameters = PokemonExtensions.CheckSearchByAndValue(searchBy, value);
            if (checkParameters != null)
            {
                resp.Message = "A request cannot me made by passing only one of the two parameters";
                return resp;
            }

            var client = new RestClient("https://pokemon-go1.p.rapidapi.com/charged_moves.json");

            var request = new RestRequest(Method.GET);
            request.BuildDefaultHeaders();

            resp.ChargedPokemonMoves = client.Execute<List<ChargedPokemonMove>>(request).Data;

            if (resp.ChargedPokemonMoves.Count == 0)
            {
                resp.Message = "Nothing from the charged pokemon moves list has been retrieved.";
                return resp;
            }

            if (!string.IsNullOrEmpty(searchBy))
            {
                List<ChargedPokemonMove> originalList = resp.ChargedPokemonMoves;
                resp.ChargedPokemonMoves = resp.ChargedPokemonMoves.FilterChargedPokemonMovesList(searchBy, value);
                if (resp.ChargedPokemonMoves.Count == originalList.Count || resp.ChargedPokemonMoves.Count == 0)
                {
                    resp.Message = "No filter could be made by using the provided parameters. Did you mean to send something else?";
                    resp.ChargedPokemonMoves = null;
                    return resp;
                }
                resp.Success = true;
                resp.Message = "Charged Pokemon Moves list filtered successfully.";
                return resp;
            }

            resp.Success = true;
            resp.Message = "Charged Pokemon Moves list retrieved successfully.";
            return resp;
        }
    }
}
