using System;
using System.Net.Http;
using System.Reflection;
using Sample.Core.Framework.Attributes;

namespace Sample.Core.Framework.Extensions
{
    public static partial class Extensions
    {
        // public static HttpAttributeInfo GetAttributeInfo(this MethodInfo t, Type attributeType)
        // {
        //     switch (attributeType.Name)
        //     {
        //         case nameof(GetAttribute):
        //             var attribute = Attribute.GetCustomAttribute(t, attributeType) as HttpAttribute;
        //             return new HttpAttributeInfo(attribute.Endpoint, HttpMethod.Get);
        //         default:
        //             throw new Exception($"{nameof(attributeType)}: {attributeType.Name} not found.");
        //     }
        // }
        
        public static HttpAttributeInfo GetHttpAttributeInfo(this MethodInfo method)
        {
            var methodAttributes = method.GetCustomAttributes(typeof(HttpAttribute), true);

            if (methodAttributes.Length <= 0)
                throw new Exception($"{nameof(HttpAttribute)} not set on {method.Name}");
            
            var attributeType = methodAttributes[0].GetType();
            
            switch (attributeType.Name)
            {
                case nameof(GetAttribute):
                    var attribute = Attribute.GetCustomAttribute(method, attributeType) as HttpAttribute;
                    return new HttpAttributeInfo(attribute.Endpoint, HttpMethod.Get);
                default:
                    throw new Exception($"{nameof(attributeType)}: {attributeType.Name} not found.");
            }
        }
    }
}