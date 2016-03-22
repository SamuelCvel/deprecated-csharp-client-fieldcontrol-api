using System;
using System.Runtime.Serialization;
using RestSharp;
using Newtonsoft.Json;
using FieldControlApi.Requests;
using FieldControlApi.Exceptions;
using FieldControlApi.Responses;

namespace FieldControlApi
{
    public class Client
    {
        private IConfiguration _configuration = null;
        private string _authenticationToken = null;

        public Client(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Authenticate(string email, string password)
        {
            var authenticationRequest = new AuthenticateRequest(email, password);

            var restRequest = new RestRequest(authenticationRequest.Resource);
            restRequest.AddObject(authenticationRequest.GetPayload());

            var response = CreateClient().Execute(restRequest);

            var authenticationResponse = new AuthenticateResponse(response.Content);

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

            var restRequest = new RestRequest(request.Resource);
            restRequest.Method = (Method)Enum.Parse(typeof(Method), request.Method, true);
            restRequest.AddObject(request.GetPayload());
            restRequest.AddHeader("x-access-token", request.Token);

            var restResponse = CreateClient().Execute(restRequest);

            TResponse response = (TResponse)Activator.CreateInstance(typeof(TResponse), restResponse.Content);
            return response;
        }

        private IRestClient CreateClient()
        {
            return new RestClient(_configuration.BaseUrl);
        }
    }
}
