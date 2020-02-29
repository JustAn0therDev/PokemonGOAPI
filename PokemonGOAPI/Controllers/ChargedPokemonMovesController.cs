using System;
using System.Collections.Generic;
using RestSharp;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Entities.Arguments.Responses;
using Microsoft.AspNetCore.Mvc;

namespace PokemonGOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChargedPokemonMovesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery]string searchBy, [FromQuery]string value)
        {
            try
            {
                var checkParameters = PokemonExtensions.CheckSearchByAndValue(searchBy, value);
                if (checkParameters != null)
                    return BadRequest(checkParameters.Value);

                var resp = new ChargedPokemonMovesResponse();
                var client = new RestClient("https://pokemon-go1.p.rapidapi.com/charged_moves.json");

                var request = new RestRequest(Method.GET);
                request.BuildDefaultHeaders();

                resp.ChargedPokemonMoves = client.Execute<List<ChargedPokemonMove>>(request).Data;

                if (resp.ChargedPokemonMoves.Count == 0)
                {
                    resp.Message = "Nothing from the charged pokemon moves list has been retrieved.";
                    return StatusCode(500, resp);
                }

                if (!string.IsNullOrEmpty(searchBy))
                {
                    List<ChargedPokemonMove> originalList = resp.ChargedPokemonMoves;
                    resp.ChargedPokemonMoves = resp.ChargedPokemonMoves.FilterChargedPokemonMovesList(searchBy, value);
                    if (resp.ChargedPokemonMoves.Count == originalList.Count || resp.ChargedPokemonMoves.Count == 0)
                    {
                        resp.Message = "No filter could be made by using the provided parameters. Did you mean to send something else?";
                        resp.ChargedPokemonMoves = null;
                        return BadRequest(resp);
                    }
                    resp.Success = true;
                    resp.Message = "Charged Pokemon Moves list filtered successfully.";
                    return Ok(resp);
                }

                resp.Success = true;
                resp.Message = "Charged Pokemon Moves list retrieved successfully.";
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new DefaultResponse(false, ex.Message));
            }
        }
    }
}
