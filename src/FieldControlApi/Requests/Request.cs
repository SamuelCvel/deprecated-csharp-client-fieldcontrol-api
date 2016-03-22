using FieldControlApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Requests
{
    public class RequestParameter
    {
        public RequestParameter(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public string Value { get; set; }
    }

    public abstract class Request
    {
        protected Request(RequestParameter[] segments = null, RequestParameter[] parameters = null)
        {
            UrlSegments = segments;
            Parameters = parameters;
        }

        protected Request(Resource resource)
        {
            Resource = resource;
        }

        public RequestParameter[] Parameters { get; set; }
        public RequestParameter[] UrlSegments { get; set; }
        public string Token { get; set; }
        public abstract string ResourcePath { get; }
        public Resource Resource { get; private set; }
        public abstract string Method { get; }
    }

    public abstract class Request<TResponse> : Request
        where TResponse : class
    {
        protected Request(Resource resource) 
            : base(resource)
        {
        }

        protected Request(RequestParameter[] segments = null, RequestParameter[] parameters = null) 
            : base(segments, parameters)
        {
        }
    }

}
