using PokemonGOAPI.Interfaces;

namespace PokemonGOAPI.Entities
{
    public class DefaultResponse : IResponse
    {
        #region Public Members

        public bool Success { get; set; }
        public string Message { get; set; }

        #endregion

        #region Constructors

        public DefaultResponse()
        {

        }

        public DefaultResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        #endregion
    }
}