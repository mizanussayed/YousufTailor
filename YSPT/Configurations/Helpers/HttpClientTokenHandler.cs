//using System.Net.Http.Headers;


//namespace YSPT.Configurations.Helpers;

//public class HttpClientTokenHandler : DelegatingHandler
//{
//    private readonly HttpClient _httpClient = new()
//    {
//        BaseAddress = new Uri(Constants.ApiBaseUrl)
//    };
//    private readonly IRefreshTokenService _refreshTokenService;

//    public HttpClientTokenHandler()
//    {
//        _refreshTokenService = new RefreshTokenService(_httpClient);
//    }

//    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
//    {
//        await SetToken(request, cancellationToken).ConfigureAwait(false);
//        return await base.SendAsync(request, cancellationToken);
//    }

//    private async Task SetToken(HttpRequestMessage request, CancellationToken cancellationToken)
//    {
//        var (result, accessTokenExpireTime) = await AuthenticationService.GetLoginInfo();
//        if (string.IsNullOrEmpty(result.AccessToken))
//        {
//            return;
//        }

//        if (accessTokenExpireTime <= DateTime.Now)
//        {
//            var newToken = await _refreshTokenService.GetNewRefreshToken(new NewTokenRequestModel
//            {
//                RefreshToken = result.RefreshToken,
//                Username = result.UserInfo?.UserName ?? string.Empty,
//            }, cancellationToken).ConfigureAwait(false);

//            if (newToken.Data is not null)
//            {
//                await AuthenticationService.SetLoginInfo(new UserLoginResponseModel
//                {
//                    AccessToken = newToken.Data.AccessToken,
//                    AccessTokenExpireInMinutes = newToken.Data.AccessTokenExpireInMinutes,
//                    RefreshToken = newToken.Data.RefreshToken,
//                    UserInfo = new UserModel
//                    {
//                        UserName = result.UserInfo?.UserName ?? string.Empty,
//                    }
//                });

//                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", newToken.Data.AccessToken);

//                return;
//            }
//        }

//        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);
//    }
//}
