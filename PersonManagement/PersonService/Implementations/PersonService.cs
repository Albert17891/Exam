using Mapster;
using PersonManagement.Model;
using PersonManagement.Rebository;
using PersonService.Abstractions;
using PersonService.Model;
using PersonService.StatusCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonService.Implementations
{
    public class PersonServices : IPersonService
    {
        private readonly IPersonRepository _repository;

        public PersonServices(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(Person person)
        {

            var per = person.Adapt<PersonRebo>();

           await _repository.Create(per);

            

        }

        public async Task<Status> Delete(int Id)
        {
          await  _repository.Delete(Id);

          return Status.Sucsses;
        }

        public async Task<Person> GetPersonAsync(int Id)
        {
           var res= await _repository.GetPerson(Id);

            return res.Adapt<Person>();

        }

        public async Task<List<Person>> GetPersonsAsync()
        {
            var res = await _repository.GetPersons();

            var pes = res.Adapt<List<Person>>();


            return pes ;
        }

        public async Task<Status> UpdateAsync(Person person)
        {
            var personRepo = person.Adapt<PersonRebo>();
            
            await _repository.Update(personRepo);

            return Status.Sucsses;

        }
    }
}
