using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Exceptions
{
    [Serializable]
    public class AuthenticationException : ApplicationException
    {
        public AuthenticationException()
            : base("Authencation failed")
        {
        }
    }
}
