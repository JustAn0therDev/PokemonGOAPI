using System.Collections.Generic;
using PokemonGOAPI.Interfaces;

namespace PokemonGOAPI.Entities.Arguments
{
    public class WeatherBoostsResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Dictionary<string, List<string>> WeatherBoosts { get; set; } = new Dictionary<string, List<string>>();
    }
}
