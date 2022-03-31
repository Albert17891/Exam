namespace MoviesManagement.Services.Abstractions
{
    public interface IJWTService
    {
        string GenerateToken(string username, string roleName);
    }
}
