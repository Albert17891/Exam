using PersonService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonService.StatusCode;

namespace PersonService.Abstractions
{
    public interface IPersonService
    {
        Task<List<Person>> GetPersonsAsync();
        Task<Person> GetPersonAsync(int Id);

        Task CreateAsync(Person person);

        Task<Status> UpdateAsync(Person person);

        Task<Status> Delete(int Id);


    }
}
