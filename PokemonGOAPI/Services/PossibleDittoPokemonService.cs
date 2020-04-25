using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;
using PokemonGOAPI.Utils;
using RestSharp;
using System.Collections.Generic;

namespace PokemonGOAPI.Services
{
    public class PossibleDittoPokemonService : BaseService, IPossibleDittoPokemonService
    {
        public override RestClient RestClient {
            get => new RestClient("https://pokemon-go1.p.rapidapi.com/possible_ditto_pokemon.json");
        }

        public PossibleDittoPokemonResponse GetPossibleDittoPokemon()
        {
            Dictionary<string, List<PokemonNameObject>> possibleDittoPokemonDictionary = RestClient.Execute<Dictionary<string, List<PokemonNameObject>>>(RestRequest)?.Data;

            if (possibleDittoPokemonDictionary == null || (possibleDittoPokemonDictionary != null && possibleDittoPokemonDictionary.Count == 0))
                return ResponseFactory<PossibleDittoPokemonResponse>.NothingReturnedFromTheRequestedList();

            return ListWasRetrievedSuccessfully(possibleDittoPokemonDictionary);
        }

        private PossibleDittoPokemonResponse ListWasRetrievedSuccessfully(Dictionary<string, List<PokemonNameObject>> possibleDittoPokemonDictionary) 
            => new PossibleDittoPokemonResponse {
                Success = true,
                Message = "Possible Ditto Pokemon list retrieved successfully",
                PossibleDittoPokemon = possibleDittoPokemonDictionary
            };
    }
}