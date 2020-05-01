using PokemonGOAPI.Interfaces;

namespace System
{
    public static class ResponseFactory<T> where T : IResponse, new()
    {
        public static T BothRequiredValuesForFilteringWereNotProvided()
            => new T
            {
                Message = "Cannot filter a list without both required values."
            };

        public static T NothingReturnedFromTheRequestedList()
            =>  new T
            {
                Message = "Nothing from the requested list has been retrieved."
            };

        public static T ListFilteringDidntWork()
            => new T
            {
                Message = "No filter could be made by using the provided parameters. Did you mean to send something else?"
            };
    }
}
