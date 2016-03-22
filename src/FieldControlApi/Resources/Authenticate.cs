using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Resources
{
    public class AuthenticateResult : Resource
    {
        public bool Success { get; set; }
        public string Token { get; set; }
    }

    public class Authenticate : Resource
    {
        public Authenticate(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }

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
