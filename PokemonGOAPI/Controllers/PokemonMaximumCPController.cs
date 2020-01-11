using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using RestSharp;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Entities.Arguments;

namespace PokemonGOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonMaximumCPController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            PokemonMaximumCPResponse resp = new PokemonMaximumCPResponse();

            try
            {
                var client = new RestClient("https://pokemon-go1.p.rapidapi.com/pokemon_max_cp.json");

                var request = new RestRequest(Method.GET);
                request.BuildDefaultHeaders();

                resp.PokemonMaximumCPList = client.Execute<List<PokemonMaximumCP>>(request).Data;

                if (resp.PokemonMaximumCPList.Count == 0)
                {
                    resp.Message = "Nothing was found in the Pokemon Maximum CP list.";
                    return NotFound(resp);
                }

                resp.Success = true;
                resp.Message = "Pokemon Maximum CP list retrieved succesfully!";
                return Ok(resp);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new DefaultResponse(false, ex.Message));
            }
        }
    }
}
