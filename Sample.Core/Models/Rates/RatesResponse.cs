using System.Net.Http;
using Newtonsoft.Json;

namespace Sample.Core.Models.Rates
{
    public class RatesResponse : HttpResponseMessage
    {
        [JsonProperty("rate")]
        public Rate Rate { get; set; }
    }
}