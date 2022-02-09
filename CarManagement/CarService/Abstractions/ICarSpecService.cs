using CarService.Model;
using CarService.Model.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Abstractions
{
    public interface ICarSpecService
    {
       
        Task<CarSpecification> GetSpecCar(int Id);

        Task Update(int Id,CarSpecification carSpec);

        Task Delete(int Id);
    }
}
