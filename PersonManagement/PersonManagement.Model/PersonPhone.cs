using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Model
{
    public class PersonPhone
    {
       public int PersonId { get; set; }
       public int PhoneId { get; set; }

       public PersonRebo Person { get; set; }
       public PhoneRepo Phone { get; set; }
    }
}
