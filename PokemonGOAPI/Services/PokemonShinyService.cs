using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;
using PokemonGOAPI.Utils;
using RestSharp;
using System.Collections.Generic;

namespace PokemonGOAPI.Services
{
    public class PokemonShinyService : BaseService, IPokemonShinyService
    {
        public override RestClient RestClient {
            get => new RestClient("https://pokemon-go1.p.rapidapi.com/shiny_pokemon.json");
        }

        public PokemonShinyResponse GetPokemonShiny()
        {
            Dictionary<string, List<PokemonShiny>> shinyPokemonDictionary = RestClient.Execute<Dictionary<string, List<PokemonShiny>>>(RestRequest)?.Data;

            if (shinyPokemonDictionary != null && shinyPokemonDictionary.Count == 0)
                return ResponseFactory<PokemonShinyResponse>.NothingReturnedFromTheRequestedList();

            return ListWasRetrievedSuccessfully(shinyPokemonDictionary);
        }

        private PokemonShinyResponse ListWasRetrievedSuccessfully(Dictionary<string, List<PokemonShiny>> shinyPokemonDictionary)
            => new PokemonShinyResponse {
                Success = true,
                Message = "Pokemon Shiny list returned successfully.",
                PokemonShinyList = shinyPokemonDictionary
            };
    }
}
