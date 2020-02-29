using PokemonGOAPI.Entities.Arguments.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonGOAPI.Interfaces.Services
{
    public interface IPokemonBuddyDistancesService
    {
        PokemonBuddyDistancesResponse GetPokemonBuddyDistances(string distanceInKm);
    }
}
