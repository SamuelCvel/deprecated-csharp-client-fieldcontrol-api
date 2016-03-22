using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Responses
{
    public class Response<TResource>
        where TResource : class
    {
        protected TResource _responseObject = null;
        protected string _responseContent = null;

        public Response(string responseContent)
        {
            _responseContent = responseContent;
            _responseObject = JsonConvert.DeserializeObject<TResource>(_responseContent);
        }

        public TResource GetResource()
        {
            return _responseObject;
        }
    }
}
