using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPersonManagement.Model.Request;
using PersonManagement.Model.Login_Model;
using PersonService.Abstractions;
using PersonService.Model;
using System.Threading.Tasks;

namespace MyPersonManagement.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _service;
        public AccountController(IUserService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(UserCreateModel createModel)
        {
            if (createModel == null)
            {
                return BadRequest();
            }

            var user = createModel.Adapt<User>();
            var res =await _service.Register(user);

            return StatusCode((int)res);

        }
        [AllowAnonymous]
        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<string>> Login(string username,string password)
        {
            var token = await _service.Login(username,password);

            return token;

        }

    }
}
