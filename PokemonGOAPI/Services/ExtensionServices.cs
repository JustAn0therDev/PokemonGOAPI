using RestSharp;
using PokemonGOAPI.Configurations;

namespace System
{
    public static class ExtensionServices
    {
        public static void BuildDefaultHeaders(this RestRequest req)
        {
            req.AddHeader("X-RapidAPI-Host", "pokemon-go1.p.rapidapi.com");
            req.AddHeader("X-RapidAPI-Key", Config.APIKey);
            req.AddHeader("Accept", "application/json");
        }
    }
}
