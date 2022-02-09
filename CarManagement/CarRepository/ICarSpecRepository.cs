using CarRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepository
{
    public interface ICarSpecRepository
    {
       
        Task<CarModel> GetSpecCar(int Id);

        Task Update(int Id,CarModel carSpec);

        Task Delete(int Id);
    }
}
