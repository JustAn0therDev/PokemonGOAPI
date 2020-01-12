using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Entities.Arguments;
using RestSharp;

namespace PokemonGOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonCandyController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery]string numberOfCandies)
        {
            try
            {
                var result = new PokemonCandyResponse();
                var client = new RestClient("https://pokemon-go1.p.rapidapi.com/pokemon_candy_to_evolve.json");

                var request = new RestRequest();
                request.BuildDefaultHeaders();

                result.AllPokemonCandy = client.Execute<Dictionary<string, List<PokemonCandy>>>(request).Data;

                if (result.AllPokemonCandy.Count == 0)
                {
                    result.Message = "Nothing returned from the Pokemon Candy list.";
                    return StatusCode(500, result);
                }

                if (!string.IsNullOrEmpty(numberOfCandies))
                {
                    Dictionary<string, List<PokemonCandy>> originalList = result.AllPokemonCandy;
                    result.AllPokemonCandy = result.AllPokemonCandy.FilterPokemonListByNumberOfCandiesAndGroupByPokemonId(numberOfCandies);

                    if (result.AllPokemonCandy.Count == originalList.Count || result.AllPokemonCandy.Count == 0)
                    {
                        result.Message = "A filter using the sent parameters could not be made, did you mean to send something else?";
                        result.AllPokemonCandy = null;
                        return BadRequest(result);
                    }
                    result.Success = true;
                    result.Message = $"List of Pokemon that need {numberOfCandies} candies to evolve retrieved successfully!";
                    return Ok(result);
                }
                result.Success = true;
                result.Message = "Pokemon Candy list returned successfully.";
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new DefaultResponse(false, ex.Message));
            }
        }
    }
}
