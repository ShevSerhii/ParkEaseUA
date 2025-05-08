namespace ParkingPlatform.WebAPI.Routes;

public static class ApiRoutes
{
    public const string Base = "/api/auth";

    public const string Register = $"{Base}/register";
    public const string Login = $"{Base}/login";
    public const string OnlyDriver = $"{Base}/only-driver";
    public const string ForgotPassword = $"{Base}/forgot-password";
    public const string ResetPassword = $"{Base}/reset-password";
}