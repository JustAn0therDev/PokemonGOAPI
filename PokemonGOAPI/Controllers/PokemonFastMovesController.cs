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
    public class PokemonFastMovesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var resp = new PokemonFastMovesResponse();
                var client = new RestClient("https://pokemon-go1.p.rapidapi.com/fast_moves.json");

                var request = new RestRequest(Method.GET);
                request.BuildDefaultHeaders();

                resp.PokemonFastMoves = client.Execute<List<PokemonFastMoves>>(request).Data;

                if (resp.PokemonFastMoves.Count == 0)
                {
                    resp.Message = "Nothing returned from the Pokemon fast moves list.";
                    return StatusCode(500, resp);
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
