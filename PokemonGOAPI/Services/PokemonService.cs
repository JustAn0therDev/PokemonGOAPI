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
    }
}
