using PersonManagement.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonManagement.Rebository
{
    public interface IPersonRepository
    {
        Task<List<PersonRebo>> GetPersons();

        Task<PersonRebo> GetPerson(int Id);

        Task Create(PersonRebo person);

        Task Update(PersonRebo person);

        Task Delete(int Id);

    }
}
