using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sample.Core.Framework.Attributes;
using Sample.Core.Models.Orders;
using Sample.Core.Models.Rates;
using Sample.Core.Models.Taxes;
using Sample.Core.Services;

namespace Sample.Core.Service
{
    public interface ITaxService
    {
        public Task<RatesResponse> GetTaxRate(string zip);
        public Task<TaxesResponse> CalculateTaxes(Order order);
    }
    
    public class TaxService : BaseHttpService, ITaxService
    {
        public TaxService()
        {
            Client = new HttpClient();
            ContentType = "application/json";
            Client.BaseAddress = TaxRateConfig.BaseAddress;
            AuthorizationHeader = ("Authorization", $"Token token=\"{TaxRateConfig.PublicKey}\"");
        }
        
        [Get("v2/rates/{zip}")]
        public async Task<RatesResponse> GetTaxRate(string zip)
        {
            var request = await CreateRequestMessage(args: zip);
            var response = await Client.SendAsync(request);
            
            if (!response.IsSuccessStatusCode)
                return null;
    
            var jsonContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RatesResponse>(jsonContent);
            return result;
        }

        [Post("v2/taxes")]
        public async Task<TaxesResponse> CalculateTaxes([Body] Order order)
        {
            var request = await CreateRequestMessage(args: order);
            var response = await Client.SendAsync(request);
            
            if (!response.IsSuccessStatusCode)
                return null;
    
            var jsonContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TaxesResponse>(jsonContent);
            return result;
        }
        // {
        //     var endpoint = $"api/v1/collections/";
        //     var queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
        //
        //     queryString.Add(nameof(offset), $"{offset}");
        //     queryString.Add(nameof(limit), $"{limit}");
        //     
        //     var response = await _client.GetAsync($"{endpoint}?{queryString}");
        //     if (!response.IsSuccessStatusCode)
        //         return null;
        //
        //     var jsonContent = await response.Content.ReadAsStringAsync();
        //     var result = JsonUtilities.Deserialize<IEnumerable<OpenSeaCollections>>(jsonContent, true);
        //     return result;
        // }
    }
}