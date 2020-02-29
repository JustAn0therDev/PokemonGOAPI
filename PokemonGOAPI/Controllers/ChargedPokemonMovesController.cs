﻿using Microsoft.AspNetCore.Mvc;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Interfaces.Services;
using System;

namespace PokemonGOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChargedPokemonMovesController : ControllerBase
    {
        #region Private Members

        private readonly IChargedPokemonMovesService _chargedPokemonMovesService;

        #endregion

        #region Constructors

        public ChargedPokemonMovesController(IChargedPokemonMovesService chargedPokemonMovesService)
        {
            _chargedPokemonMovesService = chargedPokemonMovesService;
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public IActionResult Get([FromQuery]string searchBy, [FromQuery]string value)
        {
            try
            {
                var resp = _chargedPokemonMovesService.GetChargedPokemonMoves(searchBy, value);

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
