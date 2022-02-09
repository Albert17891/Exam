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
    public class CarSpecService : ICarSpecService
    {
        private readonly ICarSpecRepository _specifService;
        public CarSpecService(ICarSpecRepository specifService)
        {
            _specifService = specifService;
        }

        public async Task Delete(int Id)
        {
           await _specifService.Delete(Id);
        }

        public async Task<CarSpecification> GetSpecCar(int Id)
        {
            var res =await _specifService.GetSpecCar(Id);

            var carSpec = res.Adapt<CarSpecification>();

            return carSpec;
        }

        public async Task Update(int Id,CarSpecification carSpec)
        {
            var res = carSpec.Adapt<CarModel>();

          await  _specifService.Update(Id,res);
        }
    }
}
