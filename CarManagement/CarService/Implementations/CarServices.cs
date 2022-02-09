using CarRepository;
using CarRepository.Model;
using CarService.Abstractions;
using CarService.Model;
using CarService.Model.Status;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Implementations
{
    public class CarServices : ICarService
    {

        private readonly IRepositoryService _repository;

        public CarServices(IRepositoryService repository)
        {
            _repository = repository;
        }
        public async Task<StatusCode> CreateCar(Car car)
        {
            var res = car.Adapt<CarModel>();

           await _repository.CreateCar(res);

            return StatusCode.Sucsses;
        }

        public async Task Delete(int Id)
        {
           await _repository.Delete(Id);
        }

        public async Task<Car> GetCar(int Id)
        {
            var res = await _repository.GetCar(Id);

            var car = res.Adapt<Car>();

            return car;
        }

        public async Task<List<Car>> GetCars()
        {
            var res =await _repository.GetCars();

            var car = res.Adapt<List<Car>>();

            return car;

        }

        public Task Update(Car car)
        {
            var res = car.Adapt<CarModel>();

            _repository.Update(res);

            return Task.CompletedTask;
        }
    }
}
