using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;
using PokemonGOAPI.Utils;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PokemonGOAPI.Services
{
    public class ChargedPokemonMovesService : BaseService, IChargedPokemonMovesService
    {
        public override RestClient RestClient { 
            get => new RestClient("https://pokemon-go1.p.rapidapi.com/charged_moves.json");
        }

        public ChargedPokemonMovesResponse GetChargedPokemonMoves(string searchBy, string value)
        {
            if (ReceivedArgumentsAreNotValid(searchBy, value))
                return ResponseFactory<ChargedPokemonMovesResponse>.BothRequiredValuesForFilteringWereNotProvided();

            List<ChargedPokemonMove> chargedPokemonMoves = RestClient.Execute<List<ChargedPokemonMove>>(RestRequest)?.Data;

            if (chargedPokemonMoves == null || chargedPokemonMoves.Count == 0)
                return ResponseFactory<ChargedPokemonMovesResponse>.NothingReturnedFromTheRequestedList();

            if (ArgumentsAreValidAndNotEmpty(searchBy, value))
            {
                List<ChargedPokemonMove> originalListFromRequestToCompareAfterFiltering = chargedPokemonMoves;
                chargedPokemonMoves = chargedPokemonMoves.FilterChargedPokemonMovesList(searchBy, value);

                if (chargedPokemonMoves == null || (chargedPokemonMoves.Count == 0 || chargedPokemonMoves.Count == originalListFromRequestToCompareAfterFiltering.Count))
                    return ResponseFactory<ChargedPokemonMovesResponse>.ListFilteringDidntWork();

                return ListWasFilteredSuccessfully(chargedPokemonMoves);
            }
            return ListWasRetrievedSuccessfully(chargedPokemonMoves);
        }

        private ChargedPokemonMovesResponse ListWasFilteredSuccessfully(List<ChargedPokemonMove> chargedPokemonMoves)
            => new ChargedPokemonMovesResponse {
                Success = true,
                Message = "Charged Pokemon Moves list filtered successfully.",
                ChargedPokemonMoves = chargedPokemonMoves
            };

        private ChargedPokemonMovesResponse ListWasRetrievedSuccessfully(List<ChargedPokemonMove> chargedPokemonMoves)
            => new ChargedPokemonMovesResponse {
                Success = true,
                Message = "Charged Pokemon Moves list retrived successfully.",
                ChargedPokemonMoves = chargedPokemonMoves
            };
    }
}