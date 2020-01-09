using Microsoft.AspNetCore.Mvc;
using System;
using RestSharp;
using System.Collections.Generic;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Entities.Arguments;
using PokemonGOAPI.Services;

namespace PokemonGOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonBuddyDistancesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery]string distanceInKm)
        {
            PokemonBuddyDistancesResponse resp = new PokemonBuddyDistancesResponse();
            try
            {
                var client = new RestClient("https://pokemon-go1.p.rapidapi.com/pokemon_buddy_distances.json");

                var request = new RestRequest();
                request.BuildDefaultHeaders();

                var response = client.Execute<Dictionary<string, List<PokemonBuddyDistance>>>(request);

                resp.PokemonBuddyDistances = response.Data;
                resp.Success = true;

                if (!string.IsNullOrEmpty(distanceInKm))
                {
                    resp.PokemonBuddyDistances = resp.PokemonBuddyDistances.FilterPokemonBuddyDistancesBySearchAndValue(distanceInKm);
                    if (resp.PokemonBuddyDistances != null)
                        if (resp.PokemonBuddyDistances.Values.Count == 0)
                        {
                            resp.Success = false;
                            resp.Message = $"No Pokemon that need {distanceInKm}KM in distance has been found. Did you mean to send something else?";
                            return NotFound(resp);
                        }

                    resp.Message = $"A list of pokemon that need matching {distanceInKm}KM in distance has been retrieved successfully.";
                    return Ok(resp);
                }
                else
                {
                    resp.Message = "Pokemon buddy distance list retrieved succesfully.";
                }
                return Ok(resp);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new DefaultResponse(false, ex.Message));
            }
        }
    }
}
