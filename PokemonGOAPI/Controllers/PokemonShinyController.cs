using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Entities.Arguments;
using RestSharp;

namespace PokemonGOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonShinyController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var resp = new PokemonShinyResponse();
                var client = new RestClient("https://pokemon-go1.p.rapidapi.com/shiny_pokemon.json");

                var request = new RestRequest(Method.GET);
                request.BuildDefaultHeaders();

                resp.PokemonShinyList = client.Execute<Dictionary<string, List<PokemonShiny>>>(request).Data;

                if(resp.PokemonShinyList.Count == 0)
                {
                    resp.Message = "Nothing returned from the Pokemon Shiny list.";
                    return StatusCode(500, resp);
                }

                resp.Success = true;
                resp.Message = "Pokemon Shiny list returned successfully.";
                return Ok(resp);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new DefaultResponse(false, ex.Message));
            }
        }
    }

}
