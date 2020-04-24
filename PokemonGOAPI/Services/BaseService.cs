using System;
using RestSharp;

namespace PokemonGOAPI.Services
{
    public abstract class BaseService {
        private RestRequest _restRequest;
        protected RestRequest RestRequest { 
            get {
                if (_restRequest == null) {
                    _restRequest = new RestRequest();
                    _restRequest.BuildDefaultHeaders();
                }
                return _restRequest;
            } 
        }
        public virtual RestClient RestClient { 
            get { 
                throw new NotImplementedException("Client has not been implemented for the current subclass.");
            } 
        }
    }
}