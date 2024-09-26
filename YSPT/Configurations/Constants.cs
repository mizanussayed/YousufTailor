namespace YSPT.Configurations;

public class Constants
{
    public const string AuthType = "SecureStorageAuth";
    public const string SecureStorageAccessToken = "token";
    public const string SecureStorageAccessTokenExpireInMinutes = "access_token_expire_in_minutes";
    public const string SecureStorageAccessTokenExpireTime = "access_token_set_time";
    public const string SecureStorageUsername = "username";
    public const string SecureStorageFullName = "fullname";
    public const string SecureStorageRefreshToken = "refresh_token";
    public const string SecureStorageUserInfo = "userInfo";
#if DEBUG
    public const string ApiBaseUrl = "https://demo.com/";
#else
    public const string ApiBaseUrl = "https://demo.com/abc";
#endif
}
