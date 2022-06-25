using System;
using System.Collections.Generic;
using System.Net;

namespace Sample.API.Responses
{
    public interface IResponseBase
    {
        int Code { get; set; }
        string Message { get; set; }
        HttpStatusCode StatusCode { get; set; }
        Dictionary<string, object> Params { get; set; }
        Exception HandledException { get; set; }
    }

    public class ResponseBase : IResponseBase
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public Dictionary<string, object> Params { get; set; }
        public Exception HandledException { get; set; }
    }

    public class ResponseBase<T> : List<T>, IResponseBase
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public Dictionary<string, object> Params { get; set; }
        public Exception HandledException { get; set; }
    }
}
