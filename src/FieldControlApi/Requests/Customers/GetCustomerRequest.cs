﻿using FieldControlApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Requests.Activities
{
    public class GetCustomerRequest : Request<Customer>
    {
        public GetCustomerRequest(string id) : base(segments: new RequestParameter[] { new RequestParameter("id", id) })
        {
        }

        public override string ResourcePath { get { return "customers/{id}"; } }
        public override string Method { get { return "GET"; } }
    }
}
