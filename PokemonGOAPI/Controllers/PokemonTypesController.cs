using Microsoft.AspNetCore.Mvc;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Interfaces;
using PokemonGOAPI.Interfaces.Services;
using System;

namespace PokemonGOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonTypesController : ControllerBase
    {
        #region Private Members

        private readonly IPokemonTypesService _pokemonTypesService;

        #endregion

        #region Constructors
        public PokemonTypesController(IPokemonTypesService pokemonTypesService)
        {
            _pokemonTypesService = pokemonTypesService;
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public IActionResult Get([FromQuery]string pokemonName)
        {
            try
            {
                IResponse resp = _pokemonTypesService.GetPokemonTypes(pokemonName);
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
