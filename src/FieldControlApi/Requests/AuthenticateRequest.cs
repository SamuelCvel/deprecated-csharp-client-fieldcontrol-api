using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Requests
{
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
