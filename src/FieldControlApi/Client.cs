using System;
using System.Runtime.Serialization;
using RestSharp;
using Newtonsoft.Json;
using FieldControlApi.Requests;
using FieldControlApi.Exceptions;
using FieldControlApi.Responses;
using FieldControlApi.Lib;
using FieldControlApi.Resources;

namespace FieldControlApi
{
    public class Client
    {
        private IHttpRequester _httpRequester = null;
        public string AuthenticationToken { get; set; }

        public Client(IConfiguration configuration)
        {
            _httpRequester = new HttpRequester(configuration);
        }

        internal Client(IHttpRequester httpRequester)
        {
            _httpRequester = httpRequester;
        }

        public void Authenticate(string email, string password)
        {
            var resource = new Authenticate(email, password);
            var response = _httpRequester.ExecuteRequest(new AuthenticateRequest(resource));
            var authenticationResponse = new AuthenticateResponse(response.ResponseContent);
            var authenticate = authenticationResponse.GetResource();

            if (!authenticate.Success)
            {
                throw new AuthenticationException();
            }

            AuthenticationToken = authenticate.Token;
        }

        protected virtual void SetAuthenticationToken(Request request)
        {
            if (string.IsNullOrEmpty(AuthenticationToken))
            {
                throw new ClientNotAuthenticatedException();
            }

            request.Token = AuthenticationToken;
        }

        public TResponse Send<TResponse>(Request<TResponse> request)
            where TResponse : class
        {
            SetAuthenticationToken(request);
            var restResponse = _httpRequester.ExecuteRequest(request);
            var response = (Response<TResponse>)Activator.CreateInstance(typeof(Response<TResponse>), restResponse.ResponseContent);
            var resource = response.GetResource();
            return resource;
        }
    }
}
