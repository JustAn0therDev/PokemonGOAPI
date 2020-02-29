using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonGOAPI.Services
{
    public class PokemonTypesService : IPokemonTypesService
    {
        public PokemonTypesResponse GetPokemonTypes(string pokemonName)
        {
            var resp = new PokemonTypesResponse();
            var client = new RestClient("https://pokemon-go1.p.rapidapi.com/pokemon_types.json");

            var request = new RestRequest(Method.GET);
            request.BuildDefaultHeaders();
            resp.PokemonTypes = client.Execute<List<PokemonType>>(request).Data;

            if (resp.PokemonTypes.Count == 0)
            {
                resp.Message = "Nothing was retrieved from the Pokemon types list.";
                return resp;
            }

            if (!string.IsNullOrEmpty(pokemonName))
            {
                List<PokemonType> originalList = resp.PokemonTypes;
                resp.PokemonTypes = resp.PokemonTypes.Where(w => w.PokemonName.ToLower() == pokemonName.ToLower()).ToList();
                if (resp.PokemonTypes.Count == originalList.Count || resp.PokemonTypes.Count == 0)
                {
                    resp.Message = "A filter on the pokemon types list could not be made. Did you mean to send something else?";
                    resp.PokemonTypes = null;
                    return resp;
                }
                resp.Success = true;
                resp.Message = "Pokemon types list filtered successfully.";
                return resp;
            }

            resp.Success = true;
            resp.Message = "Pokemon Types list retrieved successfully.";
            return resp;
        }
    }
}
