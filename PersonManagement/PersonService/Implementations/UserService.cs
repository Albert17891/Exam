using Mapster;
using PersonManagement.Model;
using PersonManagement.Model.Login_Model;
using PersonManagement.Rebository;
using PersonService.Abstractions;
using PersonService.Model;
using PersonService.StatusCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonService.Implementations
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _repository;
        private readonly IJwtService _jwtService;

        public UserService(IUserRepository repository, IJwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }

        public async Task<string> Login(string username, string password)
        {

            var res =await _repository.Login(username, password);

            var user = res.Adapt<User>();

            var resultJwt = _jwtService.GenerateSecurityJwt(user.UserName);

            return resultJwt;
        }

        public async Task<Status> Register(User user)
        {
           

            var userRepo = user.Adapt<UserRepo>();

            var res =await _repository.Create(userRepo);

            if (res == "0")
            {
                return Status.NotFound;
            }

            return Status.Sucsses;
        }
    }
}
