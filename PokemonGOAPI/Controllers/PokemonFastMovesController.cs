using Microsoft.AspNetCore.Mvc;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Interfaces.Services;
using System;

namespace PokemonGOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonFastMovesController : ControllerBase
    {
        #region Private Members

        private readonly IPokemonFastMovesService _pokemonFastMovesService;

        #endregion

        #region Constructors

        public PokemonFastMovesController(IPokemonFastMovesService pokemonFastMovesService)
        {
            _pokemonFastMovesService = pokemonFastMovesService;
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var resp = _pokemonFastMovesService.GetPokemonFastMoves();

                if (!resp.Success)
                    return BadRequest(resp);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new DefaultResponse(false, ex.Message));
            }
        }

        #endregion
    }
}
