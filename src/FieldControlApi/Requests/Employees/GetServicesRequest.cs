using FieldControlApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Requests.Customers
{
    public class GetActiveEmployeesRequest : Request<List<Employee>>
    {
        public GetActiveEmployeesRequest(DateTime date) : base(segments: new RequestParameter[] {
            new RequestParameter("date", date.ToString("yyyy-MM-dd")) }) { 
        }

        public override string ResourcePath { get { return "employees/active/{date}"; } }
        public override string Method { get { return "GET"; } }
    }
}
