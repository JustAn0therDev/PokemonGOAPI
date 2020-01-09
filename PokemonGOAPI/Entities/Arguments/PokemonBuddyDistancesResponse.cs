using System.Collections.Generic;
using RestSharp.Deserializers;
using PokemonGOAPI.Interfaces;

namespace PokemonGOAPI.Entities.Arguments
{
    public class PokemonBuddyDistancesResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Dictionary<string, List<PokemonBuddyDistance>> PokemonBuddyDistances { get; set; } = new Dictionary<string, List<PokemonBuddyDistance>>();
    }
    public class PokemonBuddyDistance
    {
        [DeserializeAs(Name = "distance")]
        public int Distance { get; set; }
        [DeserializeAs(Name = "form")]
        public string Form { get; set; }
        [DeserializeAs(Name = "pokemon_id")]
        public int PokemonId { get; set; }
        [DeserializeAs(Name = "pokemon_name")]
        public string PokemonName { get; set; }
    }
}
