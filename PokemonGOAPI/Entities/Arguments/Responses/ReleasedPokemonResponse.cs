using System.Collections.Generic;
using PokemonGOAPI.Interfaces;

namespace PokemonGOAPI.Entities.Arguments.Responses
{
    public class ReleasedPokemonResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Dictionary<string, List<PokemonNameObject>> ReleasedPokemon { get; set; } = new Dictionary<string, List<PokemonNameObject>>();
    }
}
