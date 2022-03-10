using PersonService.Model;
using System;
using System.Collections.Generic;

namespace MyPersonManagement.Model.Request
{
    public class CreateRequestModel
    {
        public string Name { get; set; }
        public string Position { get; set; }

        public DateTime BirthDate { get; set; }
        public IdCard IdCard { get; set; }
        public List<Car> Cars { get; set; }
        public List<Phone> Phones { get; set; }
    }
}
