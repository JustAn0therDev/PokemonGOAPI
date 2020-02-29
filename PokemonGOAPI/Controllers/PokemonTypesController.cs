using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Entities.Arguments.Responses;
using Microsoft.AspNetCore.Mvc;
using PokemonGOAPI.Interfaces.Services;

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
                var resp = _pokemonTypesService.GetPokemonTypes(pokemonName);

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
