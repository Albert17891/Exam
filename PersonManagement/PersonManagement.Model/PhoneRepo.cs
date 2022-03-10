using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Model
{
    public class PhoneRepo
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int TypeId { get; set; }
        public List<PersonPhone> PersonPhones { get; set; }
    }
}
