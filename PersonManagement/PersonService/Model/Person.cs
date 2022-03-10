using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonService.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }

        public DateTime BirthDate { get; set; }

        public IdCard IdCard { get; set; }

        public List<Car> Cars { get; set; }

        public List<Phone> Phones { get; set; }
    }
}
