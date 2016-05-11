using FieldControlApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Requests.Activities
{
    public class GetActivitiesRequest : Request<List<Activity>>
    {
        public GetActivitiesRequest(DateTime scheduledTo)  : base(parameters: new RequestParameter[] {
            new RequestParameter("filter[where][scheduledTo]", scheduledTo.ToString("yyyy-MM-dd")) }) {
        }

        public override string ResourcePath { get { return "activities"; } }
        public override string Method { get { return "GET"; } }
    }
}
