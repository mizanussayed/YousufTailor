namespace YSPT.Configurations.Services;

public static class ConfigureServices
{
    public static void AddServiceConfigurations(this IServiceCollection services, IConfiguration __)
    {
       // services.AddBlazorBootstrap();

        #region Setup Http Client Services
        static void httpClientAction(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(Constants.ApiBaseUrl);
        }

        //services.AddTransient<HttpClientTokenHandler>();
        //services.AddHttpClient<IClaimPossessionService, ClaimPossessionService>(httpClientAction).AddHttpMessageHandler<HttpClientTokenHandler>();

        #endregion

        #region Auth
        services.AddAuthorizationCore(config =>
        {
            config.AddPolicy(Constants.AuthType, policy => policy.RequireAuthenticatedUser());
        });
        //services.TryAddScoped<AuthenticationStateProvider, AuthenticationService>();
        //services.AddScoped<AuthenticationService>();
        #endregion
    }
}
