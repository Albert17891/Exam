using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonService.Model
{
    public class JwtConfiguration
    {
        public string Secret { get; set; }
        public int ExpirationTime { get; set; }
    }
}
