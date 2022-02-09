using CarApi.Model.DTO;
using CarApi.Model.Request;
using CarService.Abstractions;
using CarService.Model;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarSpecifController : ControllerBase
    {
        private readonly ICarSpecService _specifService;

        public CarSpecifController(ICarSpecService specifService)
        {
            _specifService = specifService;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSpec(int Id)
        {
            var res = await _specifService.GetSpecCar(Id);

            var carSpec = res.Adapt<CarSpecDto>();

            return Ok(carSpec);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateSpec(int Id, UpdateCarSpecific uptateSpecCar)
        {


            var res = uptateSpecCar.Adapt<CarSpecification>();

            await _specifService.Update(Id, res);

            return Ok();

        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete (int Id)
        {
            await _specifService.Delete(Id);

            return Ok();
        }
    }
}
