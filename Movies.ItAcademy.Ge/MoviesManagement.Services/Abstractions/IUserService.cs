namespace MoviesManagement.Services.Abstractions
{
    public interface IUserService
    {
        string AuthenticateAsync(string userName, string roleName);
    }
}
