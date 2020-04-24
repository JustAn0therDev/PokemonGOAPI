using Microsoft.AspNetCore.Mvc;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Interfaces.Services;
using System;

namespace PokemonGOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonBuddyDistancesController : ControllerBase
    {
        #region Private Members

        private readonly IPokemonBuddyDistancesService _pokemonBuddyDistancesService;

        #endregion

        #region Constructors

        public PokemonBuddyDistancesController(IPokemonBuddyDistancesService pokemonBuddyDistancesService)
        {
            _pokemonBuddyDistancesService = pokemonBuddyDistancesService;
        }

        #endregion

        [HttpGet]
        public IActionResult Get([FromQuery]string distanceInKm)
        {
            try
            {
                var resp = _pokemonBuddyDistancesService.GetPokemonBuddyDistances(distanceInKm);

                if (!resp.Success)
                    return BadRequest(resp);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse(false, ex.Message));
            }
        }
    }
}
