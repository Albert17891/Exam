using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonService.Abstractions
{
    public interface IJwtService
    {
       
        public string GenerateSecurityJwt(string name);
    }
}
