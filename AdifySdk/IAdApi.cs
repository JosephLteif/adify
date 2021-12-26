using AdifyContracts.Ads.Response;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdifySdk
{
    public interface IAdApi
    {
        [Get("/api/Ads/sdk/getAd")]
        Task<ApiResponse<AdResponse>> GetRandomAdAsync();

        [Get("/api/Ads/getAdsById/{Id}")]
        Task<ApiResponse<GetAdByCampainResponse>> GetAdByCampainAsync(int Id);

    }
}
