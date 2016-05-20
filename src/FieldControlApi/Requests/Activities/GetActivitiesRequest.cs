using FieldControlApi.Resources;
using System;
using System.Collections.Generic;

namespace FieldControlApi.Requests.Activities
{
    public class GetActivitiesRequest : Request<List<Activity>>
    {
        public GetActivitiesRequest(DateTime scheduledTo)  : base(parameters: new RequestParameter[] {
            new RequestParameter("filter[where][scheduledTo]", scheduledTo.ToString("yyyy-MM-dd")) }) {
        }

        public GetActivitiesRequest(DateTime from, DateTime to) : base(segments: new RequestParameter[] {
            new RequestParameter("from", from.ToString("yyyy-MM-dd")),
            new RequestParameter("to", to.ToString("yyyy-MM-dd"))
        }) {
        }

        public override string ResourcePath { get { return "activities/actions/find-by-date-range/{from}/{to}"; } }
        public override string Method { get { return "GET"; } }
    }
}
