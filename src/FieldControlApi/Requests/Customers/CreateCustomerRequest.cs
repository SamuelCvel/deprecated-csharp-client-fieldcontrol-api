using FieldControlApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Requests.Customers
{
    public class CreateCustomerRequest : Request<Customer>
    {
        public CreateCustomerRequest(Customer customer)
            : base(customer)
        {
        }

        public override string ResourcePath { get { return "customers"; } }
        public override string Method { get { return "POST"; } }
    }
}
