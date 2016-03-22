using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FieldControlApi.Lib;
using FieldControlApi.Requests;

namespace FieldControlApi.Tests.Fakes
{
    public class ClientProxy : Client
    {
        public ClientProxy() 
            : base(httpRequester: null)
        {
        }

        public new void SetAuthenticationToken(Request request)
        {
            base.SetAuthenticationToken(request);
        }
    }
}
