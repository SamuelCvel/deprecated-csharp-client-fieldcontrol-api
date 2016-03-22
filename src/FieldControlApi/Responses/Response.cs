using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Responses
{
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
}
