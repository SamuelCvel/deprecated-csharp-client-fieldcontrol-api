using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Exceptions
{
    [Serializable]
    public class RequestErrorException : ApplicationException
    {
        public string ResponseBody { get; private set; }

        public RequestErrorException(int statusCode, string responseBody)
            : base(string.Format("Requested resource or action failed with HTTP status code: {0}, check ResponseBody property for more details.", statusCode))
        {
            ResponseBody = responseBody;
        }
    }
}
