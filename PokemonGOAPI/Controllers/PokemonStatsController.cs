using System;
using Microsoft.AspNetCore.Mvc;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Entities.Arguments;
using RestSharp;
using System.Collections.Generic;

namespace PokemonGOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonStatsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery]string searchBy, [FromQuery]string value)
        {
            try
            {
                var parameterCheck = PokemonExtensions.CheckSearchByAndValue(searchBy, value);
                if (parameterCheck != null)
                    return BadRequest(parameterCheck.Value);

                var response = new PokemonStatsResponse();

                if ((string.IsNullOrEmpty(searchBy) && !string.IsNullOrEmpty(value)) || (!string.IsNullOrEmpty(searchBy) && string.IsNullOrEmpty(value)))
                    return BadRequest(new DefaultResponse(false, "The parameters to search for pokemon stats cannot have one of them empty or null."));

                var client = new RestClient("https://pokemon-go1.p.rapidapi.com/pokemon_stats.json");
                var request = new RestRequest(Method.GET);
                request.BuildDefaultHeaders();

                response.PokemonData = client.Execute<List<PokemonData>>(request).Data;

                if (response.PokemonData.Count == 0)
                {
                    response.Message = "Nothing returned from the Pokemon Stats list.";
                    return StatusCode(500, response);
                }

                if (!string.IsNullOrEmpty(searchBy))
                {
                    List<PokemonData> originalList = response.PokemonData;
                    response.PokemonData = response.PokemonData.FilterPokemonList(searchBy, value);
                    if (response.PokemonData.Count == originalList.Count || response.PokemonData.Count == 0)
                    {
                        response.Message = "No filter could be made by using the provided parameters. Did you mean to send something else?";
                        response.PokemonData = null;
                        return BadRequest(response);
                    }
                    response.Success = true;
                    response.Message = "Pokemon Stats list filtered successfully.";
                    return Ok(response);
                }

                response.Success = true;
                response.Message = "API request made and data returned successfully.";
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new DefaultResponse(false, ex.Message));
            }
        }
    }
}
