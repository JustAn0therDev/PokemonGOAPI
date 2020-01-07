using System;
using Microsoft.AspNetCore.Mvc;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Entities.Arguments;
using PokemonGOAPI.Services;
using RestSharp;
using System.Collections.Generic;

namespace PokemonGOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery]string searchBy, [FromQuery]string value)
        {
            PokemonStatsResponse response = new PokemonStatsResponse();

            try
            {
                if ((string.IsNullOrEmpty(searchBy) && !string.IsNullOrEmpty(value)) || (!string.IsNullOrEmpty(searchBy) && string.IsNullOrEmpty(value)))
                    return BadRequest(new DefaultResponse(false, "The parameters to search for pokemon stats cannot have one of them empty or null."));

                var client = new RestClient("https://pokemon-go1.p.rapidapi.com/pokemon_stats.json");
                var request = new RestRequest(Method.GET);

                request.AddHeader("X-RapidAPI-Key", "4d05572d05msh8850743a12d5d73p17280fjsn86033a0fdb9a");
                request.AddHeader("Accept", "application/json");

                var result = client.Execute<List<PokemonData>>(request);

                if (result == null)
                    return StatusCode(500, new DefaultResponse(false, "Something unexpected happened and nothing returned from the API Call."));

                response.Success = true;
                response.Message = "API request made and data returned successfully.";
                response.PokemonData = result.Data;

                if (!string.IsNullOrEmpty(searchBy))
                {
                    response.PokemonData = response.PokemonData.FilterPokemonList(searchBy, value);
                    if (response.PokemonData.Count == 0)
                        response.Message = "No Pokemon has been found with the provided filter. Did you mean to send something else?";

                    return Ok(response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new DefaultResponse(false, ex.Message));
            }
        }
    }
}
