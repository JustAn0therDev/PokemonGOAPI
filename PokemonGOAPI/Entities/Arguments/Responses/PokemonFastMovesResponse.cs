using System.Collections.Generic;
using PokemonGOAPI.Interfaces;
using RestSharp.Deserializers;

namespace PokemonGOAPI.Entities.Arguments.Responses
{
    public class PokemonFastMovesResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<PokemonFastMoves> PokemonFastMoves { get; set; }
    }

    public class PokemonFastMoves
    {
        [DeserializeAs(Name = "duration")]
        public int Duration { get; set; }
        [DeserializeAs(Name = "energy_delta")]
        public int EnergyDelta { get; set; }
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }
        [DeserializeAs(Name = "power")]
        public int Power { get; set; }
        [DeserializeAs(Name = "stamina_loss_scaler")]
        public string StaminaLossScaler { get; set; }
        [DeserializeAs(Name = "type")]
        public string Type { get; set; }
    }
}
