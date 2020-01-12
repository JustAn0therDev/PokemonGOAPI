using System.Collections.Generic;
using System.Linq;
using PokemonGOAPI.Entities;
using PokemonGOAPI.Entities.Arguments;
using Microsoft.AspNetCore.Mvc;

namespace System
{
    public static class PokemonExtensions
    {
        public static List<PokemonData> FilterPokemonList(this List<PokemonData> pokemonData, string searchBy, string value)
        {
            switch (searchBy.ToLower())
            {
                case "pokemonname":
                    return pokemonData.Where(w => w.PokemonName == value).ToList();
                case "pokemonid":
                    return pokemonData.Where(w => w.PokemonId == Convert.ToInt32(value)).ToList();
                case "form":
                    return pokemonData.Where(w => w.Form == value).ToList();
                case "baseattack":
                    return pokemonData.Where(w => w.BaseAttack == Convert.ToInt32(value)).ToList();
                case "basedefense":
                    return pokemonData.Where(w => w.BaseDefense == Convert.ToInt32(value)).ToList();
                case "basestamina":
                    return pokemonData.Where(w => w.BaseStamina == Convert.ToInt32(value)).ToList();
                default:
                    return pokemonData;
            }
        }

        public static Dictionary<string, List<PokemonCandy>> FilterPokemonListByNumberOfCandiesAndGroupByPokemonId(this Dictionary<string, List<PokemonCandy>> keyValuePairs, string numberOfCandies)
        {
            List<PokemonCandy> filteredPokemonCandyList;
            keyValuePairs.TryGetValue(numberOfCandies, out filteredPokemonCandyList);

            filteredPokemonCandyList = filteredPokemonCandyList.GroupBy(gb => gb.PokemonId).Select(s => s.FirstOrDefault()).ToList();

            keyValuePairs = new Dictionary<string, List<PokemonCandy>>()
                    {
                        { numberOfCandies, filteredPokemonCandyList }
                    };
            return keyValuePairs;
        }

        public static Dictionary<string, List<PokemonBuddyDistance>> FilterPokemonBuddyDistancesBySearchAndValue(this Dictionary<string, List<PokemonBuddyDistance>> keyValuePairs, string distanceInKm)
        {
            List<PokemonBuddyDistance> filteredPokemonBuddyDistancesList;
            keyValuePairs.TryGetValue(distanceInKm, out filteredPokemonBuddyDistancesList);

            keyValuePairs = new Dictionary<string, List<PokemonBuddyDistance>>()
                    {
                        { distanceInKm, filteredPokemonBuddyDistancesList }
                    };
            return keyValuePairs;
        }

        public static List<PokemonFastMoves> FilterPokemonFastMovesList(this List<PokemonFastMoves> pokemonData, string searchBy, string value)
        {
            switch (searchBy.ToLower())
            {
                case "name":
                    return pokemonData.Where(w => w.Name == value).ToList();
                case "power":
                    return pokemonData.Where(w => w.Power == Convert.ToInt32(value)).ToList();
                case "type":
                    return pokemonData.Where(w => w.Type == value).ToList();
                case "stamina_loss_scaler":
                    return pokemonData.Where(w => w.StaminaLossScaler == value).ToList();
                case "duration":
                    return pokemonData.Where(w => w.Duration == Convert.ToInt32(value)).ToList();
                case "energy_delta":
                    return pokemonData.Where(w => w.EnergyDelta == Convert.ToInt32(value)).ToList();
                default:
                    return pokemonData;
            }
        }
        public static List<ChargedPokemonMove> FilterChargedPokemonMovesList(this List<ChargedPokemonMove> pokemonData, string searchBy, string value)
        {
            switch (searchBy.ToLower())
            {
                case "criticalchance":
                    return pokemonData.Where(w => w.CriticalChance == value).ToList();
                case "duration":
                    return pokemonData.Where(w => w.Duration == Convert.ToInt32(value)).ToList();
                case "form":
                    return pokemonData.Where(w => w.EnergyDelta == Convert.ToInt32(value)).ToList();
                case "move_id":
                    return pokemonData.Where(w => w.MoveId == Convert.ToInt32(value)).ToList();
                case "name":
                    return pokemonData.Where(w => w.Name == value).ToList();
                case "power":
                    return pokemonData.Where(w => w.Power == Convert.ToInt32(value)).ToList();
                case "stamina_loss_scaler":
                    return pokemonData.Where(w => w.StaminaLossScaler == value).ToList();
                case "type":
                    return pokemonData.Where(w => w.Type == value).ToList();
                default:
                    return pokemonData;
            }
        }

        public static List<PokemonEncounter> FilterPokemonEncountersList(this List<PokemonEncounter> pokemonData, string searchBy, string value)
        {
            switch (searchBy.ToLower())
            {
                case "attackprobability":
                    return pokemonData.Where(w => w.AttackProbability == value).ToList();
                case "base_capture_rate":
                    return pokemonData.Where(w => w.BaseCaptureRate == value).ToList();
                case "base_flee_rate":
                    return pokemonData.Where(w => w.BaseFleeRate == value).ToList();
                case "dodge_probability":
                    return pokemonData.Where(w => w.DodgeProbability == value).ToList();
                case "form":
                    return pokemonData.Where(w => w.Form == value).ToList();
                case "max_pokemon_action_frequency":
                    return pokemonData.Where(w => w.MaxPokemonActionFrequency == value).ToList();
                case "min_pokemon_action_frequency":
                    return pokemonData.Where(w => w.MinPokemonActionFrequency == value).ToList();
                case "pokemon_id":
                    return pokemonData.Where(w => w.PokemonId == Convert.ToInt32(value)).ToList();
                case "pokemon_name":
                    return pokemonData.Where(w => w.PokemonName.ToLower() == value.ToLower()).ToList();
                default:    
                    return pokemonData;
            }
        }

        public static ObjectResult CheckSearchByAndValue(string searchBy, string value)
        {
            if (string.IsNullOrEmpty(searchBy) && !string.IsNullOrEmpty(value))
                return new ObjectResult(new DefaultResponse(false, "A request cannot be made by sending a value without a key"));
            else if (string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(searchBy))
                return new ObjectResult(new DefaultResponse(false, "A request cannot be made by sending a key without a value"));
            else
                return null;
        }
    }
}
