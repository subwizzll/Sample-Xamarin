using System;

namespace Sample.Core.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class GetAttribute : HttpAttribute
    {
        public GetAttribute(string endpoint) : base(endpoint)
        {
        }
    }
}