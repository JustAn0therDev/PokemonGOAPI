using Microsoft.AspNetCore.Mvc;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Interfaces.Services;
using System;

namespace PokemonGOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReleasedPokemonController : ControllerBase
    {
        #region Private Members

        private readonly IReleasedPokemonService _releasedPokemonService;

        #endregion

        #region MyRegion

        public ReleasedPokemonController(IReleasedPokemonService releasedPokemonService)
        {
            _releasedPokemonService = releasedPokemonService;
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var resp = _releasedPokemonService.GetReleasedPokemonResponse();

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
