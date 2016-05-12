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
        private IConfiguration _configuration = null;

        public string AuthenticationToken { get; set; }

        public Client()
        {
            _httpRequester = new HttpRequester(new Configuration.Configuration() {
                BaseUrl = "http://api.fieldcontrol.com.br"
            });
        }

        public Client(IConfiguration configuration)
        {
            _httpRequester = new HttpRequester(configuration);
            _configuration = configuration;
        }

        internal Client(IHttpRequester httpRequester)
        {
            _httpRequester = httpRequester;
        }

        public void Authenticate()
        {
            Authenticate(_configuration.Username, _configuration.Password);
        }

        public void Authenticate(string email, string password)
        {
            var resource = new Authenticate(email, password);
            var request = new AuthenticateRequest(resource);
            var authenticationResult = Execute(request, authenticationRequired: false);

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

        public TResponse Execute<TResponse>(Request<TResponse> request)
            where TResponse : class
        {
            return this.Execute<TResponse>(request, authenticationRequired: true);
        }

        private TResponse Execute<TResponse>(Request<TResponse> request, bool authenticationRequired)
          where TResponse : class
        {
            if (authenticationRequired)
            {
                SetAuthenticationToken(request);
            }

            var restResponse = _httpRequester.ExecuteRequest(request);
            if (restResponse.HttpStatusCode == 200)
            {
                var response = (Response<TResponse>)Activator.CreateInstance(typeof(Response<TResponse>), restResponse.ResponseContent);
                var resource = response.GetResource();
                return resource;
            }

            throw new RequestErrorException(restResponse.HttpStatusCode, restResponse.ResponseContent);
        }

    }
}
