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
            var restRequest = new RestRequest(request.Resource);
            restRequest.Method = (Method)Enum.Parse(typeof(Method), request.Method, true);
            restRequest.AddObject(request.GetPayload());

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
