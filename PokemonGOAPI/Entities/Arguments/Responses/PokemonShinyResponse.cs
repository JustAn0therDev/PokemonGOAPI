using PokemonGOAPI.Interfaces;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace PokemonGOAPI.Entities.Arguments.Responses
{
    public class PokemonShinyResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Dictionary<string, List<PokemonShiny>> PokemonShinyList { get; set; } = new Dictionary<string, List<PokemonShiny>>();
    }
    public class PokemonShiny : IPokemonResponse
    {
        [DeserializeAs(Name = "found_egg")]
        public bool FoundEgg { get; set; }
        [DeserializeAs(Name = "found_evolution")]
        public bool FoundEvolution { get; set; }
        [DeserializeAs(Name = "found_raid")]
        public bool FoundRaid { get; set; }
        [DeserializeAs(Name = "found_research")]
        public bool FoundResearch { get; set; }
        [DeserializeAs(Name = "found_wild")]
        public bool FoundWild { get; set; }
        [DeserializeAs(Name = "id")]
        public int PokemonId { get; set; }
        [DeserializeAs(Name = "name")]
        public string PokemonName { get; set; }
    }
}
