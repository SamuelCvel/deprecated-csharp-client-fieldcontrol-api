using FieldControlApi.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FieldControlApi.Resources;

namespace FieldControlApi.Tests.Fakes
{
    public class DummyRequest : Request<DummyResource>
    {
        public DummyRequest(Resource resource) : base(resource)
        {

        }

        public override string Method
        {
            get
            {
                return "POST";
            }
        }

        public override string ResourcePath
        {
            get
            {
                return "resources";
            }
        }
    }
}
