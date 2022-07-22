using System;

namespace Sample.Core.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class PostAttribute : HttpAttribute
    {
        public PostAttribute(string endpoint) : base(endpoint)
        {
        }
    }
}