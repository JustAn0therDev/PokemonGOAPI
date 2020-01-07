using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokemonGOAPI.Entities.Arguments
{
    public class URLIntelligence : HttpContent
    {
        #region Public Properties

        [JsonProperty("target")]
        public string Target { get; set; }

        #endregion

        #region Protected Methods

        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            throw new System.NotImplementedException();
        }

        protected override bool TryComputeLength(out long length)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
