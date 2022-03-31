using Microsoft.Extensions.Logging;
using MoviesManagement.Services.Abstractions;
using System;

namespace MoviesManagement.Services.Implementations
{
    public class UserService : IUserService
    {

        private readonly IJWTService _service;
        private readonly ILogger<UserService> _logger;

        public UserService(IJWTService service, ILogger<UserService> logger)
        {
            _service = service;
            _logger = logger;
        }
        public string AuthenticateAsync(string userName, string roleName)
        {
            try
            {
                return _service.GenerateToken(userName, roleName);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Failed AuthenticateAsync");
            }
            return null;
        }
    }
}
