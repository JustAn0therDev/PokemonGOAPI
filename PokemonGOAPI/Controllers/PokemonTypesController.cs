using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Entities.Arguments;
using Microsoft.AspNetCore.Mvc;

namespace PokemonGOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonTypesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery]string pokemonName)
        {
            try
            {
                var resp = new PokemonTypesResponse();
                var client = new RestClient("https://pokemon-go1.p.rapidapi.com/pokemon_types.json");

                var request = new RestRequest(Method.GET);
                request.BuildDefaultHeaders();
                resp.PokemonTypes = client.Execute<List<PokemonType>>(request).Data;

                if (resp.PokemonTypes.Count == 0)
                {
                    resp.Message = "Nothing was retrieved from the Pokemon types list.";
                    return StatusCode(500, resp);
                }

                if(!string.IsNullOrEmpty(pokemonName))
                {
                    List<PokemonType> originalList = resp.PokemonTypes;
                    resp.PokemonTypes = resp.PokemonTypes.Where(w => w.PokemonName.ToLower() == pokemonName.ToLower()).ToList();
                    if (resp.PokemonTypes.Count == originalList.Count || resp.PokemonTypes.Count == 0)
                    {
                        resp.Message = "A filter on the pokemon types list could not be made. Did you mean to send something else?";
                        resp.PokemonTypes = null;
                        return BadRequest(resp);
                    }
                    resp.Success = true;
                    resp.Message = "Pokemon types list filtered successfully.";
                    return Ok(resp);
                }

                resp.Success = true;
                resp.Message = "Pokemon Types list retrieved successfully.";
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new DefaultResponse(false, ex.Message));
            }
        }
    }
}
