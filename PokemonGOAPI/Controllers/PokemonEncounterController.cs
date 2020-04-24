using Microsoft.AspNetCore.Mvc;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Interfaces;
using PokemonGOAPI.Interfaces.Services;
using System;

namespace PokemonGOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonEncounterController : ControllerBase
    {
        #region Private Members

        private readonly IPokemonEncounterService _pokemonEncounterService;

        #endregion

        #region Constructors

        public PokemonEncounterController(IPokemonEncounterService pokemonEncounterService)
        {
            _pokemonEncounterService = pokemonEncounterService;
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public IActionResult Get([FromQuery]string searchBy, [FromQuery]string value)
        {
            try
            {
                IResponse resp = _pokemonEncounterService.GetPokemonEncounter(searchBy, value);
                if (!resp.Success)
                    return BadRequest(resp);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse(false, ex.Message));
            }
        }

        #endregion

    }
}
