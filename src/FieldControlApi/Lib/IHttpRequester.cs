using FieldControlApi.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Lib
{
    public interface IHttpRequester
    {
        HttpRequesterResponse ExecuteRequest(Request request);
    }
}
