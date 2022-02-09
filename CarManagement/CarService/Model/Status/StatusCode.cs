using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Model.Status
{
   public enum StatusCode
    {
        NotFound=404,
        Sucsses=200,
        AlreadyExist=409
    }
}
