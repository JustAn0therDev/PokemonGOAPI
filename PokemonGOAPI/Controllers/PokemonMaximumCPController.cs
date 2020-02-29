using Microsoft.AspNetCore.Mvc;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Interfaces.Services;
using System;

namespace PokemonGOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonMaximumCPController : ControllerBase
    {
        #region Private Members

        private readonly IPokemonMaximumCPService _pokemonMaximumCPService;

        #endregion

        #region Constructors

        public PokemonMaximumCPController(IPokemonMaximumCPService pokemonMaximumCPService)
        {
            _pokemonMaximumCPService = pokemonMaximumCPService;
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var resp = _pokemonMaximumCPService.GetPokemonMaximumCP();
                if (!resp.Success)
                    return BadRequest(resp);
                else
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
