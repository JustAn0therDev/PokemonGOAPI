using System.Collections.Generic;
using PokemonGOAPI.Interfaces;

namespace PokemonGOAPI.Entities.Arguments
{
    public class PossibleDittoPokemonResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Dictionary<string, List<PokemonNameObject>> PossibleDittoPokemon { get; set; } = new Dictionary<string, List<PokemonNameObject>>();
    }
}
