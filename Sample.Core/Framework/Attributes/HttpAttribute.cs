using System;

namespace Sample.Core.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HttpAttribute : Attribute
    {
        public string Endpoint { get; set; }

        public HttpAttribute(string endpoint)
        {
            Endpoint = endpoint;
        }
    }
}