﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using RestSharp;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Entities.Arguments;

namespace PokemonGOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonMaximumCPController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var resp = new PokemonMaximumCPResponse();
                var client = new RestClient("https://pokemon-go1.p.rapidapi.com/pokemon_max_cp.json");

                var request = new RestRequest(Method.GET);
                request.BuildDefaultHeaders();

                resp.PokemonMaximumCPList = client.Execute<List<PokemonMaximumCP>>(request).Data;

                if (resp.PokemonMaximumCPList.Count == 0)
                {
                    resp.Message = "Nothing returned from the Pokemon Maximum CP list.";
                    return StatusCode(500, resp);
                }

                resp.Success = true;
                resp.Message = "Pokemon Maximum CP list retrieved succesfully!";
                return Ok(resp);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new DefaultResponse(false, ex.Message));
            }
        }
    }
}
