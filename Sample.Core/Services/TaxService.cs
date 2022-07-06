using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sample.Core.Models;

namespace Sample.Core.Service
{
    public interface ITaxService
    {
        public Task<TaxRateResponse> GetTaxRate(string zip);
        //public Task<object> CalculateTaxes(int offset = 0, int limit = 30);
    }
    
    public class TaxService : ITaxService
    {
        readonly HttpClient _client;

        public TaxService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://api.taxjar.com/");
        }
        
        public async Task<TaxRateResponse> GetTaxRate(string zip)
        {
            var contentType = "application/json";
            var httpMethod = HttpMethod.Get;
            var endpoint = $"v2/rates/{zip}";
            
            var request = new HttpRequestMessage(httpMethod, $"{_client.BaseAddress}{endpoint}")
            { 
                Content = new StringContent(string.Empty, System.Text.Encoding.UTF8, contentType) 
            };
            request.Headers.Add("Authorization", "Token token=\"5da2f821eee4035db4771edab942a4cc\"");

            var response = await _client.SendAsync(request);
            
            if (!response.IsSuccessStatusCode)
                return null;
    
            var jsonContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TaxRateResponse>(jsonContent);
            return result;
        }
        
        // public async Task<object> CalculateTaxes(int offset = 0, int limit = 30)
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