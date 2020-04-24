using RestSharp;

namespace PokemonGOAPI.Interfaces.Services
{
    public interface IService
    {
        RestRequest RestRequest { get; set; }
        RestClient RestClient { get; set; }
    }
}
