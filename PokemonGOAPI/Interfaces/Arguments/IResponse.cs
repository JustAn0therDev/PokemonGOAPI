namespace PokemonGOAPI.Interfaces
{
    public interface IResponse
    {
        bool Success { get; set; }
        string Message { get; set; }
    }
}
