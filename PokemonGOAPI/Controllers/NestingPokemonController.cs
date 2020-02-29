using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Entities;

namespace PokemonGOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NestingPokemonController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var resp = new NestingPokemonResponse();
                var client = new RestClient("https://pokemon-go1.p.rapidapi.com/nesting_pokemon.json");

                var request = new RestRequest(Method.GET);
                request.BuildDefaultHeaders();

                resp.NestingPokemon = client.Execute<Dictionary<string, List<NestingPokemon>>>(request).Data;

                if (resp.NestingPokemon.Values.Count == 0)
                {
                    resp.Message = "Nothing was found in the request nesting pokemon list.";
                    return NotFound(resp);
                }

                resp.Success = true;
                resp.Message = "Nesting pokemon list found succesfully.";
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new DefaultResponse(false, ex.Message));
            }
        }
    }
}
