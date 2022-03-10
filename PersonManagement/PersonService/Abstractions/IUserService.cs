using PersonManagement.Model.Login_Model;
using PersonService.Model;
using PersonService.StatusCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonService.Abstractions
{
    public interface IUserService
    {
        Task<Status> Register(User user);

        Task<string> Login(string username, string password);
        
    }
}
