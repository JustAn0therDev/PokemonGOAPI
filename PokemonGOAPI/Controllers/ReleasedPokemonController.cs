using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Entities.Arguments.Responses;
using RestSharp;

namespace PokemonGOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReleasedPokemonController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var resp = new ReleasedPokemonResponse();

                var client = new RestClient("https://pokemon-go1.p.rapidapi.com/released_pokemon.json");
                var request = new RestRequest(Method.GET);
                request.BuildDefaultHeaders();

                resp.ReleasedPokemon = client.Execute<Dictionary<string, List<PokemonNameObject>>>(request).Data;

                if (resp.ReleasedPokemon.Count == 0)
                {
                    resp.Message = "Nothing returned from the released pokemon list.";
                    return StatusCode(500, resp);
                }

                resp.Success = true;
                resp.Message = "Released pokemon list returned successfully.";
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new DefaultResponse(false, ex.Message));
            }
        }
    }
}
