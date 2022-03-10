using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonService.Model
{
    public class IdCard
    {
        public int PersonId { get; set; }
        public string Region { get; set; }
        public string IdIdentifaer { get; set; }
        public string NameId { get; set; }

        //public Person Person { get; set; }
    }
}
