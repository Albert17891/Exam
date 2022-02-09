using CarApi.Infastructure.Extension;
using CarApi.Model.DTO;
using CarApi.Model.Request;
using CarService.Abstractions;
using CarService.Model;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _service;

        public CarController(ICarService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var res =await _service.GetCars();
            if (res == null)
            {
                return NotFound();
            }

            var car = res.Adapt<List<CarReadDto>>();

            return Ok(car);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCar(int Id)
        {
            var res = await _service.GetCar(Id);
            if (res == null)
            {
                return NotFound();
            }

            var car = res.Adapt<CarReadDto>();

            return Ok(car);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCars(CarCreateRequest carCreate)
        {
            if (carCreate == null)
            {
                return BadRequest();
            }

            var car = carCreate.Adapt<Car>();

            if (carCreate.Currency!="GEL")
            {
                var carPriceGel = CarPriceExchange.CarGelPrice(carCreate.Currency);
                var course = await carPriceGel;
                car.CarPriceGel = (course / 100) * car.CarPrice;
            }
            else
            {
                car.CarPriceGel = car.CarPrice;
            }           

            var res =await _service.CreateCar(car);

            return Ok(res);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateCar(UpdateCarRequest updateCar)
        {
            if (updateCar == null)
            {
                return BadRequest();
            }

            var car = updateCar.Adapt<Car>();

             await _service.Update(car);

            return Ok();
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
           await _service.Delete(Id);

            return Ok();
        }

    }
}
