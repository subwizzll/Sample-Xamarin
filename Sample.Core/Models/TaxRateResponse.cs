using System.Net.Http;

namespace Sample.Core.Models
{
    public class TaxRateResponse : HttpResponseMessage
    {
        public TaxRateInfo RateInfo { get; set; }
    }
}