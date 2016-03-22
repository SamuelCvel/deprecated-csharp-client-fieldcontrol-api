using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Requests
{
    public abstract class Request
    {
        public string Token { get; set; }
        public abstract string Resource { get; }
        public abstract string Method { get; }
        public abstract object GetPayload();
    }

}
