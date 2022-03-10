using PersonManagement.Model;
using PersonManagement.Rebository;
using PersonService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagment.PersistenceDB.Implementations
{
    public class UserServiceRepo : IUserRepository
    {
        private IBaseRepository<User> _repository;
        public UserServiceRepo(IBaseRepository<User> repository)
        {
            _repository = repository;
        }
        public Task<string> Create(UserRepo userRepo)
        {
            throw new NotImplementedException();
        }

        public Task<UserRepo> Login(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
