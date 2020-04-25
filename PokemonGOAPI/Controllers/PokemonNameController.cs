using Microsoft.AspNetCore.Mvc;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Interfaces;
using PokemonGOAPI.Interfaces.Services;
using System;

namespace PokemonGOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonNameController : ControllerBase
    {
        #region Private Members

        private readonly IPokemonNameService _pokemonNameService;

        #endregion

        #region Constructors

        public PokemonNameController(IPokemonNameService pokemonNameService)
        {
            _pokemonNameService = pokemonNameService;
        }

        #endregion

        #region Public Members

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IResponse resp = _pokemonNameService.GetPokemonName();
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
