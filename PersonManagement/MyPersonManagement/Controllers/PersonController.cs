using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyPersonManagement.Model.DTO;
using MyPersonManagement.Model.Request;
using PersonService.Abstractions;
using PersonService.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyPersonManagement.Controllers
{
    //[Authorize]                   
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
                                                               
        private readonly IPersonService _service;
        private readonly ILogger<PersonController> _logger;

        public PersonController(IPersonService service,ILogger<PersonController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet] 
        public async Task<IActionResult> GetPersons()
        {
            var res =await _service.GetPersonsAsync();

            var readDto = res.Adapt<List<PersonReadDto>>();

            if (readDto == null)
            {
                return NotFound();
            }

            _logger.LogInformation("Hello");

            return Ok(readDto);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPerson(int Id)
        {
            var res = await _service.GetPersonAsync(Id);

            var readDto = res.Adapt<PersonReadDto>();

            if (readDto == null)
            {
                return NotFound();
            }


            return Ok(readDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRequestModel requestModel)
        {
            var res = requestModel.Adapt<Person>();

           await _service.CreateAsync(res);


            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateRequestModel updateModel)
        {
            var res = updateModel.Adapt<Person>();

            var person =await _service.UpdateAsync(res);


            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
         var status= await  _service.Delete(Id);

            return StatusCode((int)status);
        }

    }
}
