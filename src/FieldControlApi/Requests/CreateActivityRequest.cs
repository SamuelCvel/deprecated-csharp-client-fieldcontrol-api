using FieldControlApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Requests
{
    public class CreateActivityRequest : Request<Activity>
    {
        public CreateActivityRequest(Activity activity)
            : base(activity)
        {
        }

        public override string ResourcePath { get { return "activities"; } }
        public override string Method { get { return "POST"; } }
    }

    public class GetActivityRequest : Request<Activity>
    {
        public GetActivityRequest(string id)
            : base(new UrlSegment("id", id))
        {
        }

        public override string ResourcePath { get { return "activities/{id}"; } }
        public override string Method { get { return "GET"; } }
    }
}
