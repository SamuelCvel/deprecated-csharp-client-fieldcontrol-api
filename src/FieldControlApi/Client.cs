using RestSharp;

namespace FieldControlApi
{
    public class Client
    {
        private IConfiguration _configuration;

        public Client(IConfiguration configuration) {
            _configuration = configuration;
        }

        public TResponse Send<TRequest, TResponse>(TRequest request, string authenticationToken)
            where TRequest : Request
            where TResponse : Response
        {
            var restClient = new RestClient(_configuration.BaseUrl);
            var restRequest = new RestRequest(request.Resource);

            restRequest.AddHeader("x-access-token", authenticationToken);
            restRequest.AddObject(request.GetPayload());

            var response = restClient.Execute(restRequest);

            return null;
        }
    }

    public class Response
    {
 
    }

    public abstract class Request
    {
        public string Resource { get; }
        public abstract object GetPayload();
    }
}
