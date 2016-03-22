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
        private string _authenticationToken = null;

        public Client(IConfiguration configuration)
        {
            _httpRequester = new HttpRequester(configuration);
        }

        public void Authenticate(string email, string password)
        {
            var response = _httpRequester.ExecuteRequest(new AuthenticateRequest(email, password));

            var authenticationResponse = new AuthenticateResponse(response.ResponseContent);

            if (!authenticationResponse.Success)
            {
                throw new AuthenticationException();
            }

            _authenticationToken = authenticationResponse.Token;
        }

        protected virtual void SetAuthenticationToken(Request request)
        {
            if (string.IsNullOrEmpty(_authenticationToken))
            {
                throw new ClientNotAuthenticatedException();
            }

            request.Token = _authenticationToken;
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
