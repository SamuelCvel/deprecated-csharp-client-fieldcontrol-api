using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Responses
{
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
}
