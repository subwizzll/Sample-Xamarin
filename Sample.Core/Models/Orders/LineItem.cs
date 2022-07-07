using Newtonsoft.Json;

namespace Sample.Core.Models.Orders
{
    public class LineItem
    {
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("unit_price")]
        public double UnitPrice { get; set; }
    }
}