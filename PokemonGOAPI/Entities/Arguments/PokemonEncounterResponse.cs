using System.Collections.Generic;
using PokemonGOAPI.Interfaces;
using RestSharp.Deserializers;

namespace PokemonGOAPI.Entities.Arguments
{
    public class PokemonEncounterResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<PokemonEncounter> PokemonEncounters { get; set; } = new List<PokemonEncounter>();
    }

    public class PokemonEncounter : IPokemonResponse
    {
        [DeserializeAs(Name = "attack_probability")]
        public string AttackProbability { get; set; }
        [DeserializeAs(Name = "base_capture_rate")]
        public string BaseCaptureRate { get; set; }
        [DeserializeAs(Name = "base_flee_rate")]
        public string BaseFleeRate { get; set; }
        [DeserializeAs(Name = "dodge_probability")]
        public string DodgeProbability { get; set; }
        [DeserializeAs(Name = "form")]
        public string Form { get; set; }
        [DeserializeAs(Name = "max_pokemon_action_frequency")]
        public string MaxPokemonActionFrequency { get; set; }
        [DeserializeAs(Name = "min_pokemon_action_frequency")]
        public string MinPokemonActionFrequency { get; set; }
        [DeserializeAs(Name = "pokemon_id")]
        public int PokemonId { get; set; }
        [DeserializeAs(Name = "pokemon_name")]
        public string PokemonName { get; set; }
    }
}
