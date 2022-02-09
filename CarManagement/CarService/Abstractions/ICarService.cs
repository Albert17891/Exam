using CarService.Model;
using CarService.Model.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Abstractions
{
    public interface ICarService
    {
        Task<StatusCode> CreateCar(Car car);
        Task<List<Car>> GetCars();
        Task<Car> GetCar(int Id);

        Task Update(Car car);

        Task Delete(int Id);

    }
}
