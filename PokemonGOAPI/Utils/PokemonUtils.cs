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
            return (searchBy.ToLower()) switch
            {
                "pokemonname" => pokemonList.Where(w => w.PokemonName == value).ToList(),
                "pokemonid" => pokemonList.Where(w => w.PokemonId == Convert.ToInt32(value)).ToList(),
                "form" => pokemonList.Where(w => w.Form == value).ToList(),
                "baseattack" => pokemonList.Where(w => w.BaseAttack == Convert.ToInt32(value)).ToList(),
                "basedefense" => pokemonList.Where(w => w.BaseDefense == Convert.ToInt32(value)).ToList(),
                "basestamina" => pokemonList.Where(w => w.BaseStamina == Convert.ToInt32(value)).ToList(),
                _ => pokemonList,
            };
        }

        public static Dictionary<string, List<PokemonCandy>> FilterPokemonListByNumberOfCandiesAndGroupByPokemonId(
            this Dictionary<string, List<PokemonCandy>> pokemonCandyDictionary,
            string numberOfCandies
            )
        {
            pokemonCandyDictionary.TryGetValue(numberOfCandies, out List<PokemonCandy> filteredPokemonCandyList);

            if (filteredPokemonCandyList != null)
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
            return (searchBy.ToLower()) switch
            {
                "name" => pokemonFastMovesList.Where(w => w.Name == value).ToList(),
                "power" => pokemonFastMovesList.Where(w => w.Power == Convert.ToInt32(value)).ToList(),
                "type" => pokemonFastMovesList.Where(w => w.Type == value).ToList(),
                "stamina_loss_scaler" => pokemonFastMovesList.Where(w => w.StaminaLossScaler == value).ToList(),
                "duration" => pokemonFastMovesList.Where(w => w.Duration == Convert.ToInt32(value)).ToList(),
                "energy_delta" => pokemonFastMovesList.Where(w => w.EnergyDelta == Convert.ToInt32(value)).ToList(),
                _ => pokemonFastMovesList,
            };
        }
        public static List<ChargedPokemonMove> FilterChargedPokemonMovesList(
            this List<ChargedPokemonMove> chargedPokemonMovesList,
             string searchBy,
             string value)
        {
            return (searchBy.ToLower()) switch
            {
                "criticalchance" => chargedPokemonMovesList.Where(w => w.CriticalChance == value).ToList(),
                "duration" => chargedPokemonMovesList.Where(w => w.Duration == Convert.ToInt32(value)).ToList(),
                "form" => chargedPokemonMovesList.Where(w => w.EnergyDelta == Convert.ToInt32(value)).ToList(),
                "move_id" => chargedPokemonMovesList.Where(w => w.MoveId == Convert.ToInt32(value)).ToList(),
                "name" => chargedPokemonMovesList.Where(w => w.Name == value).ToList(),
                "power" => chargedPokemonMovesList.Where(w => w.Power == Convert.ToInt32(value)).ToList(),
                "stamina_loss_scaler" => chargedPokemonMovesList.Where(w => w.StaminaLossScaler == value).ToList(),
                "type" => chargedPokemonMovesList.Where(w => w.Type == value).ToList(),
                _ => chargedPokemonMovesList,
            };
        }

        public static List<PokemonEncounter> FilterPokemonEncountersList(
            this List<PokemonEncounter> pokemonEncountersList,
            string searchBy,
            string value)
        {
            return (searchBy.ToLower()) switch
            {
                "attackprobability" => pokemonEncountersList.Where(w => w.AttackProbability == value).ToList(),
                "base_capture_rate" => pokemonEncountersList.Where(w => w.BaseCaptureRate == value).ToList(),
                "base_flee_rate" => pokemonEncountersList.Where(w => w.BaseFleeRate == value).ToList(),
                "dodge_probability" => pokemonEncountersList.Where(w => w.DodgeProbability == value).ToList(),
                "form" => pokemonEncountersList.Where(w => w.Form == value).ToList(),
                "max_pokemon_action_frequency" => pokemonEncountersList.Where(w => w.MaxPokemonActionFrequency == value).ToList(),
                "min_pokemon_action_frequency" => pokemonEncountersList.Where(w => w.MinPokemonActionFrequency == value).ToList(),
                "pokemon_id" => pokemonEncountersList.Where(w => w.PokemonId == Convert.ToInt32(value)).ToList(),
                "pokemon_name" => pokemonEncountersList.Where(w => w.PokemonName.ToLower() == value.ToLower()).ToList(),
                _ => pokemonEncountersList,
            };
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
