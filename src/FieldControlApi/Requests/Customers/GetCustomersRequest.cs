using FieldControlApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Requests.Customers
{
    public class GetCustomersRequest : Request<List<Customer>>
    {
        public GetCustomersRequest(string nameLike) : base(parameters: new RequestParameter[] {
            new RequestParameter("filter[where][name]", nameLike) }) {
        }

        public override string ResourcePath { get { return "customers"; } }
        public override string Method { get { return "GET"; } }
    }
}
