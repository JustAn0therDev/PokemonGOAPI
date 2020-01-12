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
    public class PokemonEncounterController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery]string searchBy, [FromQuery]string value)
        {
            try
            {
                var checkParameters = PokemonExtensions.CheckSearchByAndValue(searchBy, value);
                if (checkParameters != null)
                    return BadRequest(checkParameters.Value);

                var resp = new PokemonEncounterResponse();
                var client = new RestClient("https://pokemon-go1.p.rapidapi.com/pokemon_encounter_data.json");

                var request = new RestRequest(Method.GET);
                request.BuildDefaultHeaders();

                resp.PokemonEncounters = client.Execute<List<PokemonEncounter>>(request).Data;

                if (resp.PokemonEncounters.Count == 0)
                {
                    resp.Message = "Nothing returned from the Pokemon Encounter list.";
                    return NotFound(resp);
                }

                if(!string.IsNullOrEmpty(searchBy))
                {
                    List<PokemonEncounter> originalList = resp.PokemonEncounters;
                    resp.PokemonEncounters = resp.PokemonEncounters.FilterPokemonEncountersList(searchBy, value);
                    if (resp.PokemonEncounters.Count == originalList.Count || resp.PokemonEncounters.Count == 0)
                    {
                        resp.Message = "No filter could be made by using the provided parameters. Did you mean something else?";
                        return Ok(resp);
                    }
                    resp.Success = true;
                    resp.Message = "Pokemon Encounter list filtered successfully.";
                    return Ok(resp);
                }

                resp.Success = true;
                resp.Message = "Pokemon Encounter list returned successfully.";
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new DefaultResponse(false, ex.Message));
            }
        }
    }
}
