using System.Collections.Generic;
using RestSharp.Deserializers;
using PokemonGOAPI.Interfaces;

namespace PokemonGOAPI.Entities.Arguments.Responses
{
    public class RaidExclusivePokemonResponse : IResponse 
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Dictionary<string, List<RaidExclusivePokemon>> RaidExclusivePokemon { get; set; } = new Dictionary<string, List<RaidExclusivePokemon>>(); 
    }

    public class RaidExclusivePokemon : IPokemonResponse
    {
        [DeserializeAs(Name = "id")]
        public int PokemonId { get; set; }
        [DeserializeAs(Name = "name")]
        public string PokemonName { get; set; }
        [DeserializeAs(Name = "raid_level")]
        public int RaidLevel { get; set; }
    }
}
