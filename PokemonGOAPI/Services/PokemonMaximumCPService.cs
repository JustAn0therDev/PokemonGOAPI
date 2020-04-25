using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;
using PokemonGOAPI.Utils;
using RestSharp;
using System.Collections.Generic;

namespace PokemonGOAPI.Services
{
    public class PokemonMaximumCPService : BaseService, IPokemonMaximumCPService
    {
        public override RestClient RestClient {
            get => new RestClient("https://pokemon-go1.p.rapidapi.com/pokemon_max_cp.json");
        }

        public PokemonMaximumCPResponse GetPokemonMaximumCP()
        {
            List<PokemonMaximumCP> pokemonMaximumCPs = RestClient.Execute<List<PokemonMaximumCP>>(RestRequest)?.Data;
            if (pokemonMaximumCPs == null || (pokemonMaximumCPs != null && pokemonMaximumCPs.Count == 0))
                return ResponseFactory<PokemonMaximumCPResponse>.NothingReturnedFromTheRequestedList();

            return ListWasRetrievedSuccessfully(pokemonMaximumCPs);
        }

        private PokemonMaximumCPResponse ListWasRetrievedSuccessfully(List<PokemonMaximumCP> pokemonMaximumCPs) 
            => new PokemonMaximumCPResponse {
                Success = true,
                Message = "List of Pokemon Max CPs retrieved successfully",
                PokemonMaximumCPList = pokemonMaximumCPs
            };
    }
}