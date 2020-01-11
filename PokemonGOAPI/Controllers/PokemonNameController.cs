using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using Microsoft.AspNetCore.Mvc;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Entities.Arguments;

namespace PokemonGOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonNameController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var resp = new PokemonNameResponse();
                var client = new RestClient("https://pokemon-go1.p.rapidapi.com/pokemon_names.json");

                var request = new RestRequest(Method.GET);
                request.BuildDefaultHeaders();

                resp.PokemonNames = client.Execute<Dictionary<string, List<PokemonNameObject>>>(request).Data;

                if (resp.PokemonNames.Count == 0)
                {
                    resp.Message = "Nothing returned from the Pokemon Name list.";
                    return NotFound(resp);
                }

                resp.Success = true;
                resp.Message = "Pokemon names list retrieved successfully.";
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new DefaultResponse(false, ex.Message));
            }
        }
    }
}
