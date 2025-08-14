namespace MoodDiaryFierce;

public static class Constants
{
    public static readonly string[] Admins = [
        "_admin_",
        "_test_"
    ];
    public static readonly string AccessToken = "access-token";
    public static readonly string AccessTokenKey = "ZGRnhwkG8Ap32AaR71tnuDKArtqW2wp1";
    public static readonly TimeSpan AccessTokenMaxAge = TimeSpan.FromMinutes(30);
    public static readonly string RefreshToken = "refresh-token";
    public static readonly string RefreshTokenKey = "ey4YrQtpTn6UJrWDb6C8XAJEjg3d0nbb";
    public static readonly TimeSpan RefreshTokenMaxAge = TimeSpan.FromDays(7);
    public static readonly string ShortLivedToken = "short-live-token";
    public static readonly string ShortLivedTokenKey = "dFLUSRF59XCNG14GAjNU6BUKPrjUVa0p";
    public static readonly TimeSpan ShortLivedTokenMaxAge = TimeSpan.FromSeconds(30);

    public static readonly string AuthScheme = "auth-scheme"; 
    public static readonly string AuthToken = "auth-token"; 
    public static readonly TimeSpan AuthTokenMaxAge = TimeSpan.FromDays(7);
}
