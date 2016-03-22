using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Exceptions
{
    [Serializable]
    public class ClientNotAuthenticatedException : ApplicationException
    {
        public ClientNotAuthenticatedException()
            : base("Client is not authenticated, you must call Authenticate method before sending requests.")
        {
        }
    }
}
