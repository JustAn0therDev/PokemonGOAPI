using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Entities.Arguments;
using PokemonGOAPI.Services;
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
            var result = new PokemonCandyResponse();
            try
            {
                var client = new RestClient("https://pokemon-go1.p.rapidapi.com/pokemon_candy_to_evolve.json");

                var request = new RestRequest();
                request.BuildDefaultHeaders();

                var response = client.Execute<Dictionary<string, List<PokemonCandy>>>(request);

                if (response.Data == null)
                {
                    result.Success = false;
                    result.Message = "No data returned from the request made. Did you mean to send something else?";
                    return NotFound(result);
                }

                result.AllPokemonCandy = response.Data;

                if (!string.IsNullOrEmpty(numberOfCandies))
                {
                    result.Success = true;
                    result.AllPokemonCandy = result.AllPokemonCandy.FilterPokemonListByNumberOfCandiesAndGroupByPokemonId(numberOfCandies);

                    if (result.AllPokemonCandy.Values.FirstOrDefault() != null)
                    {
                        result.Message = $"List of Pokemon that need {numberOfCandies} candies to evolve retrieved successfully!";
                        return Ok(result);
                    }
                    result.Message = $"No pokemon that need {numberOfCandies} candies to evolve has been found on the list. Did you mean to search for something else?";
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
