using System;

namespace PokemonGOAPI.Configurations
{
    public static class Config
    {
        public static string APIKey
        {
            get
            {
                return Environment.GetEnvironmentVariable("XRAPIDAPIKEY");
            }
        }
    }
}
