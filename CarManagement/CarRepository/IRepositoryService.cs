using CarRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepository
{
    public interface IRepositoryService
    {
        Task CreateCar(CarModel car);
        Task<List<CarModel>> GetCars();
        Task<CarModel> GetCar(int Id);

        Task Update(CarModel car);

        Task Delete(int Id);
    }
}
