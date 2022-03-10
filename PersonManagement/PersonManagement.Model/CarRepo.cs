using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Model
{
    public class CarRepo
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Mark { get; set; }
        public string CarID { get; set; }
        public DateTime ProduceDate { get; set; }

        public PersonRebo Person {get;set;}
    }
}
