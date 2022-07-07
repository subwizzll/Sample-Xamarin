using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sample.Core.Framework.Attributes;
using Sample.Core.Models;
using Sample.Core.Services;

namespace Sample.Core.Service
{
    public interface ITaxService
    {
        public Task<TaxRateResponse> GetTaxRate(string zip);
        //public Task<object> CalculateTaxes(int offset = 0, int limit = 30);
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
        public async Task<TaxRateResponse> GetTaxRate(string zip)
        {
            var request = await CreateRequestMessage(args: zip);
            var response = await Client.SendAsync(request);
            
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