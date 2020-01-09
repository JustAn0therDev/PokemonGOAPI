using PokemonGOAPI.Interfaces;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace PokemonGOAPI.Entities.Arguments
{
    public class NestingPokemonResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Dictionary<string, List<NestingPokemon>> NestingPokemon { get; set; } = new Dictionary<string, List<NestingPokemon>>();
    }
    public class NestingPokemon
    {
        [DeserializeAs(Name = "id")]
        public int Id { get; set; }
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }
    }
}
