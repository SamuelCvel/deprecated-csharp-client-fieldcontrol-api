using System;
using System.Runtime.Serialization;
using RestSharp;
using Newtonsoft.Json;
using FieldControlApi.Requests;
using FieldControlApi.Exceptions;
using FieldControlApi.Responses;
using FieldControlApi.Lib;

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
            var response = _httpRequester.ExecuteRequest(new AuthenticateRequest(email, password));

            var authenticationResponse = new AuthenticateResponse(response.ResponseContent);

            if (!authenticationResponse.Success)
            {
                throw new AuthenticationException();
            }

            AuthenticationToken = authenticationResponse.Token;
        }

        protected virtual void SetAuthenticationToken(Request request)
        {
            if (string.IsNullOrEmpty(AuthenticationToken))
            {
                throw new ClientNotAuthenticatedException();
            }

            request.Token = AuthenticationToken;
        }

        public TResponse Send<TRequest, TResponse>(TRequest request)
               where TRequest : Request
               where TResponse : Response
        {
            SetAuthenticationToken(request);
            var response = _httpRequester.ExecuteRequest(request);
            return (TResponse)Activator.CreateInstance(typeof(TResponse), response.ResponseContent);
        }
    }
}
