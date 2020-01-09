using System;
using System.Collections.Generic;
using System.Linq;
using PokemonGOAPI.Entities.Arguments;

namespace PokemonGOAPI.Services
{
    public static class PokemonServices
    {
        public static List<PokemonData> FilterPokemonList(this List<PokemonData> pokemonData, string searchBy, string value)
        {
            switch (searchBy.ToLower())
            {
                case "pokemonname":
                    return pokemonData.Where(w => w.PokemonName.ToLower() == value.ToLower()).ToList();
                case "pokemonid":
                    return pokemonData.Where(w => w.PokemonId == Convert.ToInt32(value)).ToList();
                case "form":
                    return pokemonData.Where(w => w.Form == value.ToLower()).ToList();
                case "baseattack":
                    return pokemonData.Where(w => w.BaseAttack >= Convert.ToInt32(value)).ToList();
                case "basedefense":
                    return pokemonData.Where(w => w.BaseDefense >= Convert.ToInt32(value)).ToList();
                case "basestamina":
                    return pokemonData.Where(w => w.BaseStamina >= Convert.ToInt32(value)).ToList();
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
    }
}
