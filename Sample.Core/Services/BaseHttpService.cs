using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Sample.Core.Framework.Extensions;

namespace Sample.Core.Services
{
    public class BaseHttpService
    {
        protected HttpClient Client { get; set; }
        protected (string name, string value) AuthorizationHeader { get; set; }
        protected string ContentType { get; set; }
        
        protected async Task<HttpRequestMessage> CreateRequestMessage([CallerMemberName] string callerMemberName = "", string content = "", params object[] args)
        {
            var method = GetType().GetMethod(callerMemberName);
            var methodParameters = method.GetParameters();
            var attributeInfo = method.GetHttpAttributeInfo();
            
            var endpoint = await BuildEndpoint(attributeInfo.Endpoint, methodParameters, args);
            
            var request = new HttpRequestMessage(attributeInfo.Method, $"{Client.BaseAddress}{endpoint}");
            
            request.AddHeader(AuthorizationHeader);
            
            if(!string.IsNullOrWhiteSpace(content))
                request.Content = new StringContent(content, System.Text.Encoding.UTF8, ContentType);

            return request;
        }
        
        async Task<string> BuildEndpoint(string oldEndpoint, ParameterInfo[] parameterInfo, params object[] args)
        {
            var newEndpoint = oldEndpoint;
            for (int i = 0; i < args.Length; i++)
            {
                var parameterRef = $"{{{parameterInfo[i].Name}}}";
                if (oldEndpoint.Contains(parameterRef))
                    newEndpoint = oldEndpoint.Replace(parameterRef, args[i].ToString());
            }

            return newEndpoint;
        }

        
        // async Task<string> BuildEndpoint(string oldEndpoint, ParameterInfo[] parameterInfo, params object[] args)
        // {
        //     var newEndpoint = oldEndpoint;
        //     for (int i = 0; i < args.Length; i++)
        //     {
        //         var parameterRef = $"{{{parameterInfo[i].Name}}}";
        //         if (oldEndpoint.Contains(parameterRef))
        //             newEndpoint = oldEndpoint.Replace(parameterRef, args[i].ToString());
        //     }
        //
        //     return newEndpoint;
        // }
    }
}