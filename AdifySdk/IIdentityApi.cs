
using AdifyContracts.Identity;
using AdifyContracts.Response;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdifySdk
{
    public interface IIdentityApi
    {
        [Post("/api/authenticate/register")]
        Task<ApiResponse<AuthSuccessResponse>> RegisterAsync([Body]RegisterRequest registerRequest);
        [Post("/api/authenticate/register-admin")]
        Task<ApiResponse<AuthSuccessResponse>> RegisterAdminAsync([Body]RegisterRequest registerRequest);
        [Post("/api/authenticate/login")]
        Task<ApiResponse<AuthSuccessResponse>> LoginAsync([Body]LoginRequest registerRequest);
    }
}
