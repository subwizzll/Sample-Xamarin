using System.Net.Http;

namespace Sample.Core.Models
{
    public class TaxRateResponse : HttpResponseMessage
    {
        public TaxRate Rate { get; set; }
    }
}