using System.Collections.Generic;
using PokemonGOAPI.Interfaces;
using RestSharp.Deserializers;

namespace PokemonGOAPI.Entities.Arguments.Responses
{
    public class PokemonNameResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Dictionary<string, List<PokemonNameObject>> PokemonNames { get; set; } = new Dictionary<string, List<PokemonNameObject>>();
    }
    
    public class PokemonNameObject : IPokemonResponse
    {
        [DeserializeAs(Name = "id")]
        public int PokemonId { get; set; }
        [DeserializeAs(Name = "name")]
        public string PokemonName { get; set; }
    }
}
