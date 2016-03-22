using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Resources
{
    public class RouteOptimizationResult : Resource
    {
        public bool Ok { get; set; }
    }

    public class RouteOptimization : Resource
    {
        public DateTime Date { get; set; }
    }
}
