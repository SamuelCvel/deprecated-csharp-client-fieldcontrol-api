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
            var request = new AuthenticateRequest(resource);
            var authenticationResult = Send(request, authenticationRequired: false);

            if (!authenticationResult.Success)
            {
                throw new AuthenticationException();
            }

            AuthenticationToken = authenticationResult.Token;
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
            return this.Send<TResponse>(request, authenticationRequired: true);
        }

        private TResponse Send<TResponse>(Request<TResponse> request, bool authenticationRequired)
          where TResponse : class
        {
            if (authenticationRequired)
            {
                SetAuthenticationToken(request);
            }

            var restResponse = _httpRequester.ExecuteRequest(request);
            var response = (Response<TResponse>)Activator.CreateInstance(typeof(Response<TResponse>), restResponse.ResponseContent);
            var resource = response.GetResource();
            return resource;
        }

    }
}
