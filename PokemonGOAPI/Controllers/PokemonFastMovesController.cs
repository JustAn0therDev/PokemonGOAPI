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
    public class PokemonFastMovesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery]string searchBy, [FromQuery]string value)
        {
            try
            {
                var parameterCheck = PokemonExtensions.CheckSearchByAndValue(searchBy, value);
                if (parameterCheck != null)
                    return BadRequest(parameterCheck.Value);

                var resp = new PokemonFastMovesResponse();
                var client = new RestClient("https://pokemon-go1.p.rapidapi.com/fast_moves.json");

                var request = new RestRequest(Method.GET);
                request.BuildDefaultHeaders();

                resp.PokemonFastMoves = client.Execute<List<PokemonFastMoves>>(request).Data;

                if (resp.PokemonFastMoves.Count == 0)
                {
                    resp.Message = "Nothing was found in the Pokemon fast moves list.";
                    return NotFound(resp);
                }

                resp.Success = true;
                resp.Message = "Pokemon fast moves list returned successfully.";
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new DefaultResponse(false, ex.Message));
            }
        }
    }
}
