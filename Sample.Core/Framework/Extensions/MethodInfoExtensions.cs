using System;
using System.Net.Http;
using System.Reflection;
using Sample.Core.Framework.Attributes;

namespace Sample.Core.Framework.Extensions
{
    public static partial class Extensions
    {   
        public static HttpAttributeInfo GetHttpAttributeInfo(this MethodInfo method)
        {
            var methodAttributes = method.GetCustomAttributes(typeof(HttpAttribute), true);

            if (methodAttributes.Length <= 0)
                throw new Exception($"{nameof(HttpAttribute)} not set on {method.Name}");
            
            var attributeType = methodAttributes[0].GetType();
            var attribute = Attribute.GetCustomAttribute(method, attributeType) as HttpAttribute;

            var attributeInfo = attributeType.Name switch
            {
                nameof(GetAttribute) => new HttpAttributeInfo(attribute.Endpoint, HttpMethod.Get),
                nameof(PostAttribute) => new HttpAttributeInfo(attribute.Endpoint, HttpMethod.Post),
                _ => throw new Exception($"{nameof(attributeType)}: {attributeType.Name} not found.")
            };
            
            return attributeInfo;
        }
    }
}