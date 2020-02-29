using System.Collections.Generic;
using PokemonGOAPI.Interfaces;
using RestSharp.Deserializers;

namespace PokemonGOAPI.Entities.Arguments.Responses
{
    public class PokemonStatsResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<PokemonData> PokemonData { get; set; } = new List<PokemonData>();
    }

    public class PokemonData
    {
        [DeserializeAs(Name = "base_attack")]
        public int BaseAttack { get; set; }
        [DeserializeAs(Name = "base_defense")]
        public int BaseDefense { get; set; }
        [DeserializeAs(Name = "base_stamina")]
        public int BaseStamina { get; set; }
        [DeserializeAs(Name = "form")]
        public string Form { get; set; }
        [DeserializeAs(Name = "pokemon_id")]
        public int PokemonId { get; set; }
        [DeserializeAs(Name = "pokemon_name")]
        public string PokemonName { get; set; }
    }
}
