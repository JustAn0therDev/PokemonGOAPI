﻿using PokemonGOAPI.Interfaces;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace PokemonGOAPI.Entities.Arguments.Responses
{
    public class NestingPokemonResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Dictionary<string, List<NestingPokemon>> NestingPokemon { get; set; } = new Dictionary<string, List<NestingPokemon>>();
    }
    public class NestingPokemon : IPokemonResponse
    {
        [DeserializeAs(Name = "id")]
        public int PokemonId { get; set; }
        [DeserializeAs(Name = "name")]
        public string PokemonName { get; set; }
    }
}
