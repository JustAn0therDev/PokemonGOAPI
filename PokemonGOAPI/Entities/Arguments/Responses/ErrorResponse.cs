using PokemonGOAPI.Interfaces;

namespace PokemonGOAPI.Entities
{
    public class ErrorResponse : IResponse
    {
        #region Public Members

        public bool Success { get; set; }
        public string Message { get; set; }

        #endregion

        #region Constructors
        
        public ErrorResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        #endregion
    }
}