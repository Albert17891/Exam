using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonService.StatusCode
{
    public enum Status
    {
        NotFound=404,
        AlreadyExist=409,
        Sucsses=200
    }
}
