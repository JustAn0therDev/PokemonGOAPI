using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp.Deserializers;
using PokemonGOAPI.Interfaces;

namespace PokemonGOAPI.Entities.Arguments.Responses
{
    public class PokemonTypesResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<PokemonType> PokemonTypes { get; set; } = new List<PokemonType>();
    }

    public class PokemonType : IPokemonResponse
    {
        [DeserializeAs(Name = "pokemon_id")]
        public int PokemonId { get; set; }
        [DeserializeAs(Name = "pokemon_name")]
        public string PokemonName { get; set; }
        [DeserializeAs(Name = "form")]
        public string Form { get; set; }
        [DeserializeAs(Name = "type")]
        public List<string> Type { get; set; }
    }
}
