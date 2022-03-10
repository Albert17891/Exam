using Microsoft.EntityFrameworkCore;
using PersonManagement.Model;
using PersonManagement.Rebository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.PersistenceDB.Implementations
{
    public class PersonServiceRepo : IPersonRepository
    {
        private IBaseRepository<PersonRebo> _repository;
        public PersonServiceRepo(IBaseRepository<PersonRebo> repository)
        {
            _repository = repository;
        }


        public Task<PersonRebo> GetPerson(int Id)
        {
          return  _repository.Get(Id);
        }

        public async Task<List<PersonRebo>> GetPersons()
        {
            return await _repository.Table.Include(x=>x.IdCard).Include(x=>x.Cars).ToListAsync();
        }
        public async Task Create(PersonRebo person)
        {
           await _repository.Create(person);
        }

        public async Task Delete(int Id)
        {
          await  _repository.Delete(Id);
        }

       

        public async Task Update(PersonRebo person)
        {
            await _repository.Update(person);
        }
    }
}
