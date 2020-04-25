using Microsoft.AspNetCore.Mvc;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Interfaces;
using PokemonGOAPI.Interfaces.Services;
using System;

namespace PokemonGOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherBoostsController : ControllerBase
    {
        #region Private Members

        private readonly IWeatherBoostsService _weatherBoostsService;

        #endregion

        #region Constructors

        public WeatherBoostsController(IWeatherBoostsService weatherBoostsService)
        {
            _weatherBoostsService = weatherBoostsService;
        }

        #endregion

        #region Public Members

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IResponse resp = _weatherBoostsService.GetWeatherBoosts();
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
