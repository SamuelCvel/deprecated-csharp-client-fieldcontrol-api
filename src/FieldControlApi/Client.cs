using System;
using System.Runtime.Serialization;
using RestSharp;
using Newtonsoft.Json;

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

    public class CreateActivityRequest : Request
    {
        public override string Resource { get { return "activities"; } }
        public override string Method { get { return "POST"; } }

        public string Identifier { get; set; }
        public string Description { get; set; }

        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public int ServiceId { get; set; }
        public int Duration { get; set; }
        public int Status { get; set; }

        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public DateTime ScheduledTo { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime CompletedAt { get; set; }

        public string Order { get; set; }
        public bool Archived { get; set; }

        public string ProblemDescription { get; set; }
        public string CanceledDescription { get; set; }
        public bool TimeFixed { get; set; }

        public DateTime FixedStartTime { get; set; }
        public DateTime SharedLocationAt { get; set; }

        public override object GetPayload()
        {
            return this;
        }
    }

    [Serializable]
    public class AuthenticationException : ApplicationException
    {
        public AuthenticationException()
            : base("Authencation failed")
        {
        }
    }

    [Serializable]
    public class ClientNotAuthenticatedException : ApplicationException
    {
        public ClientNotAuthenticatedException()
            : base("Client is not authenticated, you must call Authenticate method before sending requests.")
        {
        }
    }

    public class Response
    {
        protected dynamic _responseObject = null;
        protected string _responseContent = null;

        protected Response(string responseContent)
        {
            _responseContent = responseContent;
            _responseObject = JsonConvert.DeserializeObject<dynamic>(_responseContent);
        }
    }

    public class AuthenticateResponse : Response
    {
        public bool Success { get; private set; }
        public string Token { get; private set; }

        public AuthenticateResponse(string responseContent)
            : base(responseContent)
        {
            Success = _responseObject.success;
            Token = _responseObject.token;
        }
    }

    public abstract class Request
    {
        public string Token { get; set; }
        public abstract string Resource { get; }
        public abstract string Method { get; }
        public abstract object GetPayload();
    }

    public class AuthenticateRequest : Request
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        public override string Resource { get { return "authenticate"; } }
        public override string Method { get { return "POST"; } }

        public AuthenticateRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public override object GetPayload()
        {
            return new
            {
                email = Email,
                password = Password
            };
        }
    }
}
