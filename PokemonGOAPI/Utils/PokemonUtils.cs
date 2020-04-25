using System.Collections.Generic;
using System.Linq;
using PokemonGOAPI.Entities.Arguments.Responses;
using Microsoft.AspNetCore.Mvc;

namespace System
{
    public static class PokemonUtils
    {
        public static List<PokemonData> FilterPokemonList(this List<PokemonData> pokemonList,
         string searchBy,
         string value)
        {
            switch (searchBy.ToLower())
            {
                case "pokemonname":
                    return pokemonList.Where(w => w.PokemonName == value).ToList();
                case "pokemonid":
                    return pokemonList.Where(w => w.PokemonId == Convert.ToInt32(value)).ToList();
                case "form":
                    return pokemonList.Where(w => w.Form == value).ToList();
                case "baseattack":
                    return pokemonList.Where(w => w.BaseAttack == Convert.ToInt32(value)).ToList();
                case "basedefense":
                    return pokemonList.Where(w => w.BaseDefense == Convert.ToInt32(value)).ToList();
                case "basestamina":
                    return pokemonList.Where(w => w.BaseStamina == Convert.ToInt32(value)).ToList();
                default:
                    return pokemonList;
            }
        }

        public static Dictionary<string, List<PokemonCandy>> FilterPokemonListByNumberOfCandiesAndGroupByPokemonId(
            this Dictionary<string, List<PokemonCandy>> pokemonCandyDictionary, 
            string numberOfCandies
            )
        {
            List<PokemonCandy> filteredPokemonCandyList;
            pokemonCandyDictionary.TryGetValue(numberOfCandies, out filteredPokemonCandyList);

            filteredPokemonCandyList = filteredPokemonCandyList.GroupBy(gb => gb.PokemonId).Select(s => s.FirstOrDefault()).ToList();

            pokemonCandyDictionary = new Dictionary<string, List<PokemonCandy>>()
                    {
                        { numberOfCandies, filteredPokemonCandyList }
                    };
            return pokemonCandyDictionary;
        }

        public static Dictionary<string, List<PokemonBuddyDistance>> FilterPokemonBuddyDistancesByDistanceInKm(
            this Dictionary<string, List<PokemonBuddyDistance>> pokemonBuddyDistanceDictionary,
            string distanceInKm
            )
        {
            List<PokemonBuddyDistance> filteredPokemonBuddyDistancesList;
            pokemonBuddyDistanceDictionary.TryGetValue(distanceInKm, out filteredPokemonBuddyDistancesList);

            pokemonBuddyDistanceDictionary = new Dictionary<string, List<PokemonBuddyDistance>>()
                    {
                        { distanceInKm, filteredPokemonBuddyDistancesList }
                    };
            return pokemonBuddyDistanceDictionary;
        }

        public static List<PokemonFastMoves> FilterPokemonFastMovesList(
            this List<PokemonFastMoves> pokemonFastMovesList,
            string searchBy,
            string value)
        {
            switch (searchBy.ToLower())
            {
                case "name":
                    return pokemonFastMovesList.Where(w => w.Name == value).ToList();
                case "power":
                    return pokemonFastMovesList.Where(w => w.Power == Convert.ToInt32(value)).ToList();
                case "type":
                    return pokemonFastMovesList.Where(w => w.Type == value).ToList();
                case "stamina_loss_scaler":
                    return pokemonFastMovesList.Where(w => w.StaminaLossScaler == value).ToList();
                case "duration":
                    return pokemonFastMovesList.Where(w => w.Duration == Convert.ToInt32(value)).ToList();
                case "energy_delta":
                    return pokemonFastMovesList.Where(w => w.EnergyDelta == Convert.ToInt32(value)).ToList();
                default:
                    return pokemonFastMovesList;
            }
        }
        public static List<ChargedPokemonMove> FilterChargedPokemonMovesList(
            this List<ChargedPokemonMove> chargedPokemonMovesList,
             string searchBy,
             string value)
        {
            switch (searchBy.ToLower())
            {
                case "criticalchance":
                    return chargedPokemonMovesList.Where(w => w.CriticalChance == value).ToList();
                case "duration":
                    return chargedPokemonMovesList.Where(w => w.Duration == Convert.ToInt32(value)).ToList();
                case "form":
                    return chargedPokemonMovesList.Where(w => w.EnergyDelta == Convert.ToInt32(value)).ToList();
                case "move_id":
                    return chargedPokemonMovesList.Where(w => w.MoveId == Convert.ToInt32(value)).ToList();
                case "name":
                    return chargedPokemonMovesList.Where(w => w.Name == value).ToList();
                case "power":
                    return chargedPokemonMovesList.Where(w => w.Power == Convert.ToInt32(value)).ToList();
                case "stamina_loss_scaler":
                    return chargedPokemonMovesList.Where(w => w.StaminaLossScaler == value).ToList();
                case "type":
                    return chargedPokemonMovesList.Where(w => w.Type == value).ToList();
                default:
                    return chargedPokemonMovesList;
            }
        }

        public static List<PokemonEncounter> FilterPokemonEncountersList(
            this List<PokemonEncounter> pokemonEncountersList,
            string searchBy,
            string value)
        {
            switch (searchBy.ToLower())
            {
                case "attackprobability":
                    return pokemonEncountersList.Where(w => w.AttackProbability == value).ToList();
                case "base_capture_rate":
                    return pokemonEncountersList.Where(w => w.BaseCaptureRate == value).ToList();
                case "base_flee_rate":
                    return pokemonEncountersList.Where(w => w.BaseFleeRate == value).ToList();
                case "dodge_probability":
                    return pokemonEncountersList.Where(w => w.DodgeProbability == value).ToList();
                case "form":
                    return pokemonEncountersList.Where(w => w.Form == value).ToList();
                case "max_pokemon_action_frequency":
                    return pokemonEncountersList.Where(w => w.MaxPokemonActionFrequency == value).ToList();
                case "min_pokemon_action_frequency":
                    return pokemonEncountersList.Where(w => w.MinPokemonActionFrequency == value).ToList();
                case "pokemon_id":
                    return pokemonEncountersList.Where(w => w.PokemonId == Convert.ToInt32(value)).ToList();
                case "pokemon_name":
                    return pokemonEncountersList.Where(w => w.PokemonName.ToLower() == value.ToLower()).ToList();
                default:
                    return pokemonEncountersList;
            }
        }

        public static ObjectResult CheckSearchByAndValue(string searchBy, string value)
        {
            if ((string.IsNullOrEmpty(searchBy) && !string.IsNullOrEmpty(value))
            || (string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(searchBy)))
                return new ObjectResult(new object());
            return null;
        }
    }
}
