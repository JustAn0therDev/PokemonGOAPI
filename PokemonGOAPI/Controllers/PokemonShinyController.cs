using Microsoft.AspNetCore.Mvc;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Interfaces;
using PokemonGOAPI.Interfaces.Services;
using System;

namespace PokemonGOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonShinyController : ControllerBase
    {
        #region Private Members

        private readonly IPokemonShinyService _pokemonShinyService;

        #endregion

        #region Constructors

        public PokemonShinyController(IPokemonShinyService pokemonShinyService)
        {
            _pokemonShinyService = pokemonShinyService;
        }

        #endregion

        #region Public Members

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IResponse resp = _pokemonShinyService.GetPokemonShiny();
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
