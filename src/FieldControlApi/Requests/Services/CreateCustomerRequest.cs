using FieldControlApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Requests.Customers
{
    public class CreateServiceRequest : Request<Service>
    {
        public CreateServiceRequest(Service service)
            : base(service)
        {
        }

        public override string ResourcePath { get { return "services"; } }
        public override string Method { get { return "POST"; } }
    }
}
