using Sample.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.API.Responses
{
    public class GoogleSearchResponse : ResponseBase, IResponseBase
    {
        public IEnumerable<GoogleSearchResult>[] Results { get; set; }
    }
}
