using FieldControlApi.Requests;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Lib
{
    public class HttpRequester : IHttpRequester
    {
        private IConfiguration _configuration = null;

        public HttpRequester(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public HttpRequesterResponse ExecuteRequest(Request request)
        {
            var restRequest = new RestRequest(request.ResourcePath);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.JsonSerializer = new CustomJsonSerializer();
            
            restRequest.Method = (Method)Enum.Parse(typeof(Method), request.Method, true);

            if (request.Resource != null) { 
                var payload = request.Resource.GetPayload();
                restRequest.AddJsonBody(payload);
            }

            if (request.UrlSegments != null && request.UrlSegments.Any())
            {
                foreach (var urlSegment in request.UrlSegments)
                {
                    restRequest.AddUrlSegment(urlSegment.Segment, urlSegment.Value);
                }
            }

            if (!string.IsNullOrEmpty(request.Token))
            {
                restRequest.AddHeader("x-access-token", request.Token);
            }

            var restResponse = CreateClient().Execute(restRequest);

            return new HttpRequesterResponse
            {
                ResponseContent = restResponse.Content,
                HttpStatusCode = (int)restResponse.StatusCode
            };
        }

        private IRestClient CreateClient()
        {
            return new RestClient(_configuration.BaseUrl);
        }
    }
}
