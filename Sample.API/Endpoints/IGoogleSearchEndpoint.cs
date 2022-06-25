using System.Threading;
using System.Threading.Tasks;
using Sample.API.Responses;
using Refit;

namespace Sample.API.Endpoints
{
    interface IGoogleSearchEndpoint : IBaseEndpoint
    {
        [Get("/v2/move-money/scheduled")]
        [Headers("Content-Type: application/json; charset=utf-8", "Authorization: Bearer")]
        Task<GoogleSearchResponse> GetSearch(string query, CancellationToken cancellationToken = default(CancellationToken));
    }
}
