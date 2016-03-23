using FieldControlApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Requests.Activities
{
    public class RouteOptimizationRequest : Request<RouteOptimizationResult>
    {
        public RouteOptimizationRequest(RouteOptimization routeOptimization) :
            base(routeOptimization) {
        }

        public override string ResourcePath { get { return "activities/actions/optimize-routes"; } }
        public override string Method { get { return "POST"; } }
    }
}
