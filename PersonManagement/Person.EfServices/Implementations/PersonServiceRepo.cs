using PersonManagement.Model;
using PersonManagement.Rebository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.EfServices.Implementations
{
    public class PersonServiceRepo : IPersonRepository
    {

        public Task<int> Create(PersonRebo person)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<PersonRebo> GetPerson(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PersonRebo>> GetPersons()
        {
            throw new NotImplementedException();
        }

        public Task Update(PersonRebo person)
        {
            throw new NotImplementedException();
        }
    }
}
