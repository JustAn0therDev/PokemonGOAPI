using RestSharp.Deserializers;
using PokemonGOAPI.Interfaces;
using System.Collections.Generic;

namespace PokemonGOAPI.Entities.Arguments.Responses
{
    public class PokemonMaximumCPResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<PokemonMaximumCP> PokemonMaximumCPList { get; set; } = new List<PokemonMaximumCP>();
    }

    public class PokemonMaximumCP : IPokemonResponse
    {
        [DeserializeAs(Name = "pokemon_id")]
        public int PokemonId { get; set; }
        [DeserializeAs(Name = "pokemon_name")]
        public string PokemonName { get; set; }
        [DeserializeAs(Name = "max_cp")]
        public int MaxCP { get; set; }
        [DeserializeAs(Name = "form")]
        public string Form { get; set; }
    }
}
