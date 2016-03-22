using FieldControlApi.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Tests.Fakes
{
    public class DummyRequest : Request
    {
        public override string Method
        {
            get
            {
                return "POST";
            }
        }

        public override string Resource
        {
            get
            {
                return "resources";
            }
        }

        public override object GetPayload()
        {
            return null;
        }
    }
}
