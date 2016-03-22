using FieldControlApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Requests
{
    public class UrlSegment
    {
        public UrlSegment(string segment, string value)
        {
            Segment = segment;
            Value = value;
        }

        public string Segment { get; set; }
        public string Value { get; set; }
    }

    public abstract  class Request {
        protected Request(UrlSegment urlSegment)
        {
            UrlSegments = new UrlSegment[] {
                urlSegment
                };
        }

        protected Request(UrlSegment[] urlSegments)
        {
            UrlSegments = urlSegments;
        }

        protected Request(Resource resource)
        {
            Resource = resource;
        }

        public UrlSegment[] UrlSegments { get; set; }
        public string Token { get; set; }
        public abstract string ResourcePath { get; }
        public Resource Resource { get; private set; }
        public abstract string Method { get; }
    }

    public abstract class Request<TResponse> : Request
        where TResponse : class
    {
        protected Request(Resource resource) : base(resource)
        {
        }

        protected Request(UrlSegment[] urlSegments) : base(urlSegments)
        {
        }

        protected Request(UrlSegment urlSegment) : base(urlSegment)
        {
        }
    }

}
