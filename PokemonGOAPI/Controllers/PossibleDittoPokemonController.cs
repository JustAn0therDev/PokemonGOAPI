﻿using Microsoft.AspNetCore.Mvc;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Interfaces;
using PokemonGOAPI.Interfaces.Services;
using System;

namespace PokemonGOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PossibleDittoPokemonController : ControllerBase
    {
        #region Private Members

        private readonly IPossibleDittoPokemonService _possibleDittoPokemonService;

        #endregion

        #region Constructors

        public PossibleDittoPokemonController(IPossibleDittoPokemonService possibleDittoPokemonService)
        {
            _possibleDittoPokemonService = possibleDittoPokemonService;
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IResponse resp = _possibleDittoPokemonService.GetPossibleDittoPokemon();
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
