using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonGOAPI.Interfaces
{
    public interface IResponse
    {
        bool Success { get; set; }
        string Message { get; set; }
    }
}
