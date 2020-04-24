using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using RestSharp;

namespace PokemonGOAPI.Entities.Arguments.Responses
{
    [ApiController]
    [Route("[controller]")]
    public class RaidExclusivePokemonController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                RaidExclusivePokemonResponse resp = new RaidExclusivePokemonResponse();
                var client = new RestClient("https://pokemon-go1.p.rapidapi.com/raid_exclusive_pokemon.json");
                var request = new RestRequest();

                request.BuildDefaultHeaders();

                resp.RaidExclusivePokemon = client.Execute<Dictionary<string, List<RaidExclusivePokemon>>>(request).Data;

                if (resp.RaidExclusivePokemon.Count == 0)
                {
                    resp.Success = false;
                    resp.Message = "No pokemon has been found on the requested list.";
                    return NotFound(resp);
                }

                resp.Success = true;
                resp.Message = "List retrieved successfully";
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse(false, ex.Message));
            }
        }

    }
}
