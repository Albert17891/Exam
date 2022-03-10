using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Model
{
    public class IdCardRepo
    {
        public int PersonId { get; set; }
        public string Region { get; set; }
        public string IdIdentifaer { get; set; }
        public string NameId { get; set; }

        public PersonRebo PersonRebo { get; set; }
    }
}
