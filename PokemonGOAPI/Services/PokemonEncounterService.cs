using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PokemonGOAPI.Services
{
    public class PokemonEncounterService : IPokemonEncounterService
    {
        public PokemonEncounterResponse GetPokemonEncounter(string searchBy, string value)
        {
            var resp = new PokemonEncounterResponse();

            var checkParameters = PokemonExtensions.CheckSearchByAndValue(searchBy, value);
            if (checkParameters != null)
            {
                resp.Message = "Cannot filter a pokemon stat without both required values.";
                return resp;
            }

            var client = new RestClient("https://pokemon-go1.p.rapidapi.com/pokemon_encounter_data.json");

            var request = new RestRequest(Method.GET);
            request.BuildDefaultHeaders();

            resp.PokemonEncounters = client.Execute<List<PokemonEncounter>>(request).Data;

            if (resp.PokemonEncounters.Count == 0)
            {
                resp.Message = "Nothing returned from the Pokemon Encounter list.";
                return resp;
            }

            if (!string.IsNullOrEmpty(searchBy))
            {
                List<PokemonEncounter> originalList = resp.PokemonEncounters;
                resp.PokemonEncounters = resp.PokemonEncounters.FilterPokemonEncountersList(searchBy, value);
                if (resp.PokemonEncounters.Count == originalList.Count || resp.PokemonEncounters.Count == 0)
                {
                    resp.Message = "No filter could be made by using the provided parameters. Did you mean something else?";
                    resp.PokemonEncounters = null;
                    return resp;
                }
                resp.Success = true;
                resp.Message = "Pokemon Encounter list filtered successfully.";
                return resp;
            }

            resp.Success = true;
            resp.Message = "Pokemon Encounter list returned successfully.";
            return resp;
        }
    }
}
