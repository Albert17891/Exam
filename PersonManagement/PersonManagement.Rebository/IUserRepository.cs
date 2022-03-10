using PersonManagement.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Rebository
{
    public interface IUserRepository
    {
        Task<string> Create(UserRepo userRepo);
        Task<UserRepo> Login(string username, string password);
    }
}
