using System.Collections.Generic;
using PokemonGOAPI.Interfaces;
using RestSharp.Deserializers;

namespace PokemonGOAPI.Entities.Arguments.Responses
{
    public class PokemonCandyResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Dictionary<string, List<PokemonCandy>> AllPokemonCandy { get; set; } = new Dictionary<string, List<PokemonCandy>>();
    }

    public class PokemonCandy
    {
        [DeserializeAs(Name = "candy_required")]
        public int CandyRequired { get; set; }

        [DeserializeAs(Name = "pokemon_id")]
        public int PokemonId { get; set; }

        [DeserializeAs(Name = "pokemon_name")]
        public string PokemonName { get; set; }
    }
}
