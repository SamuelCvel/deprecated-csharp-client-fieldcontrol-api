using FieldControlApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Requests
{
    public class AuthenticateRequest : Request<AuthenticateResult>
    {
        public override string ResourcePath { get { return "authenticate"; } }
        public override string Method { get { return "POST"; } }

        public AuthenticateRequest(Authenticate authenticate) 
            : base(authenticate)
        {
      
        }
    }
}
