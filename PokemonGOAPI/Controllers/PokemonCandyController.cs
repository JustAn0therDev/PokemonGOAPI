using System;
using Microsoft.AspNetCore.Mvc;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Interfaces;
using PokemonGOAPI.Interfaces.Services;

namespace PokemonGOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonCandyController : ControllerBase
    {
        #region Private Members

        private readonly IPokemonCandyService _pokemonCandyService;

        #endregion

        #region Constructors 

        public PokemonCandyController(IPokemonCandyService pokemonCandyService)
        {
            _pokemonCandyService = pokemonCandyService;
        }

        #endregion

        #region Public Members

        [HttpGet]
        public IActionResult Get([FromQuery]string numberOfCandies)
        {
            try
            {
                IResponse resp = _pokemonCandyService.GetPokemonCandy(numberOfCandies);
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
