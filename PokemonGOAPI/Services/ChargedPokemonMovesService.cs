﻿using PokemonGOAPI.Entities.Arguments.Responses;
using PokemonGOAPI.Interfaces.Services;
using PokemonGOAPI.Utils;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PokemonGOAPI.Services
{
    public class ChargedPokemonMovesService : IChargedPokemonMovesService
    {
        public RestClient RestClient { get; set; } = new RestClient("https://pokemon-go1.p.rapidapi.com/charged_moves.json");
        public RestRequest RestRequest { get; set; }

        public ChargedPokemonMovesResponse GetChargedPokemonMoves(string searchBy, string value)
        {
            RestRequest = new RestRequest();
            RestRequest.BuildDefaultHeaders();

            bool argumentsAreNotValid = CheckIfReceivedArgumentsAreNotValid(searchBy, value);
            if (argumentsAreNotValid)
                return ResponseFactory<ChargedPokemonMovesResponse>.BothRequiredValuesForFilteringWereNotProvided();

            List<ChargedPokemonMove> chargedPokemonMoves = RestClient.Execute<List<ChargedPokemonMove>>(RestRequest)?.Data;

            if (chargedPokemonMoves == null || chargedPokemonMoves.Count == 0)
                return ResponseFactory<ChargedPokemonMovesResponse>.NothingReturnedFromTheRequestedList();

            if (IfArgumentsAreValidAndNotEmpty(searchBy, value))
            {
                List<ChargedPokemonMove> originalListFromRequestToCompareAfterFiltering = chargedPokemonMoves;
                chargedPokemonMoves = chargedPokemonMoves.FilterChargedPokemonMovesList(searchBy, value);

                if (chargedPokemonMoves.Count == 0 || chargedPokemonMoves.Count == originalListFromRequestToCompareAfterFiltering.Count)
                    return ResponseFactory<ChargedPokemonMovesResponse>.ListFilteringDidntWork();

                return ChargedPokemonMovesListWasFilteredSuccessfully(chargedPokemonMoves);
            }
            return ChargedPokemonMovesListWasRetrievedSuccessfully(chargedPokemonMoves);
        }

        private bool CheckIfReceivedArgumentsAreNotValid(string searchBy, string value) 
            => PokemonUtils.CheckSearchByAndValue(searchBy, value) != null ? true : false;

        private bool IfArgumentsAreValidAndNotEmpty(string searchBy, string value)
            => !string.IsNullOrWhiteSpace(searchBy) && !string.IsNullOrWhiteSpace(value);

        private ChargedPokemonMovesResponse ChargedPokemonMovesListWasFilteredSuccessfully(List<ChargedPokemonMove> chargedPokemonMoves)
        {
            return new ChargedPokemonMovesResponse
            {
                Success = true,
                Message = "Charged Pokemon Moves list filtered successfully.",
                ChargedPokemonMoves = chargedPokemonMoves
            };
        }

        private ChargedPokemonMovesResponse ChargedPokemonMovesListWasRetrievedSuccessfully(List<ChargedPokemonMove> chargedPokemonMoves)
        {
            return new ChargedPokemonMovesResponse
            {
                Success = true,
                Message = "Charged Pokemon Moves list retrieved successfully.",
                ChargedPokemonMoves = chargedPokemonMoves
            };
        }
    }
}