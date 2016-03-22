using FieldControlApi.Requests;
using FieldControlApi.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Tests.Fakes
{
    public class DummyResponse : Response<object>
    {
        public DummyResponse(string responseContent) : base(responseContent)
        {
        }
    }
}
