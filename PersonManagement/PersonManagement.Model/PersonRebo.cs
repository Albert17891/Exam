using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Model
{
    public class PersonRebo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }

        public DateTime BirthDate { get; set; }

        public IdCardRepo IdCard { get; set; }

        public List<CarRepo> Cars { get; set; }

        public List<PersonPhone> PersonPhones{ get;set;}
    }
}
