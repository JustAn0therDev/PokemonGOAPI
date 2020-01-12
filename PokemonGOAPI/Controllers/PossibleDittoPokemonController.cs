using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Entities.Arguments;
using RestSharp;

namespace PokemonGOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PossibleDittoPokemonController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var resp = new PossibleDittoPokemonResponse();
                var client = new RestClient("https://pokemon-go1.p.rapidapi.com/possible_ditto_pokemon.json");

                var request = new RestRequest(Method.GET);
                request.BuildDefaultHeaders();

                resp.PossibleDittoPokemon = client.Execute<Dictionary<string, List<PokemonNameObject>>>(request).Data;

                if(resp.PossibleDittoPokemon.Count == 0)
                {
                    resp.Message = "Nothing returned from the Possible Ditto Pokemon list.";
                    return StatusCode(500, resp);
                }

                resp.Success = true;
                resp.Message = "Possible Ditto Pokemon list retrieved successfully";
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new DefaultResponse(false, ex.Message));
            }
        }
    }
}
