using FieldControlApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Responses
{
    public class AuthenticateResponse : Response<AuthenticateResult>
    {
        public AuthenticateResponse(string responseContent) : base(responseContent)
        {
        }
    }
}
