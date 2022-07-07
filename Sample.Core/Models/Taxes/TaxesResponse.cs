// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sample.Core.Models.Taxes
{

    public class TaxesResponse
    {
        [JsonProperty("tax")]
        public Tax Tax { get; set; }
    }
}