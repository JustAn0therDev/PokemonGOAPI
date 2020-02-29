using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PokemonGOAPI.Services
{
    public class PokemonBuddyDistancesService : IPokemonBuddyDistancesService
    {
        public PokemonBuddyDistancesResponse GetPokemonBuddyDistances(string distanceInKm)
        {
            var resp = new PokemonBuddyDistancesResponse();
            var client = new RestClient("https://pokemon-go1.p.rapidapi.com/pokemon_buddy_distances.json");

            var request = new RestRequest(Method.GET);
            request.BuildDefaultHeaders();

            resp.PokemonBuddyDistances = client.Execute<Dictionary<string, List<PokemonBuddyDistance>>>(request).Data;

            if (resp.PokemonBuddyDistances.Count == 0)
            {
                resp.Message = "Nothing was retrieved from the pokemon buddy distance list.";
                return resp;
            }

            if (!string.IsNullOrEmpty(distanceInKm))
            {
                Dictionary<string, List<PokemonBuddyDistance>> originalList = resp.PokemonBuddyDistances;
                resp.PokemonBuddyDistances = resp.PokemonBuddyDistances.FilterPokemonBuddyDistancesBySearchAndValue(distanceInKm);

                if (resp.PokemonBuddyDistances.Count == originalList.Count || resp.PokemonBuddyDistances.Values.Count == 0)
                {
                    resp.Message = $"No Pokemon that need {distanceInKm}KM in distance has been found. Did you mean to send something else?";
                    resp.PokemonBuddyDistances = null;
                    return resp;
                }
                resp.Success = true;
                resp.Message = $"A list of pokemon that need matching {distanceInKm}KM in distance has been retrieved successfully.";
                return resp;
            }
            else
            {
                resp.Success = true;
                resp.Message = "Pokemon buddy distance list retrieved succesfully.";
                return resp;
            }
        }
    }
}
