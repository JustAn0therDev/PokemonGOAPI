using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;
using PokemonGOAPI.Utils;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PokemonGOAPI.Services
{
    public class PokemonFastMovesService : BaseService, IPokemonFastMovesService
    {
        public override RestClient RestClient {
            get => new RestClient("https://pokemon-go1.p.rapidapi.com/fast_moves.json");
        }
        
        public PokemonFastMovesResponse GetPokemonFastMoves()
        {
            List<PokemonFastMoves> pokemonFastMoves = null;

            pokemonFastMoves = RestClient.Execute<List<PokemonFastMoves>>(RestRequest).Data;

            if (pokemonFastMoves != null && pokemonFastMoves.Count == 0)
                return ResponseFactory<PokemonFastMovesResponse>.NothingReturnedFromTheRequestedList();

            return ListWasRetrievedSuccessfully(pokemonFastMoves);
        }

        private PokemonFastMovesResponse ListWasRetrievedSuccessfully(List<PokemonFastMoves> pokemonFastMoves) 
            => new PokemonFastMovesResponse {
                Success = true,
                Message = "Pokemon fast moves list returned successfully.",
                PokemonFastMoves = pokemonFastMoves
            };
    }
}
