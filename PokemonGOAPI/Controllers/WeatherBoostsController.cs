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
    public class WeatherBoostsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var resp = new WeatherBoostsResponse();
                var client = new RestClient("https://pokemon-go1.p.rapidapi.com/weather_boosts.json");

                var request = new RestRequest(Method.GET);
                request.BuildDefaultHeaders();

                resp.WeatherBoosts = client.Execute<Dictionary<string, List<string>>>(request).Data;

                if (resp.WeatherBoosts.Count == 0)
                {
                    resp.Message = "Nothing returned from the weather boosts list.";
                    return NotFound(resp);
                }

                resp.Success = true;
                resp.Message = "Weather boosts list retrived successfully.";
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new DefaultResponse(false, ex.Message));
            }
        }
    }
}
