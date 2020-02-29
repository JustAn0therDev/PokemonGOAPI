using Microsoft.AspNetCore.Mvc;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Interfaces.Services;
using System;

namespace PokemonGOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NestingPokemonController : ControllerBase
    {
        #region Private Members

        private readonly INestingPokemonService _nestingPokemonService;

        #endregion

        #region Constructors

        public NestingPokemonController(INestingPokemonService nestingPokemonService)
        {
            _nestingPokemonService = nestingPokemonService;
        }

        #endregion

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var resp = _nestingPokemonService.GetNestingPokemon();

                if (!resp.Success)
                    return BadRequest(resp);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new DefaultResponse(false, ex.Message));
            }
        }
    }
}
