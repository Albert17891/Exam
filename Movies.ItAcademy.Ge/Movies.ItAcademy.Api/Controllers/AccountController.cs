using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movies.ItAcademy.Api.Models.Requests;
using MoviesManagement.Domain.Enum;
using MoviesManagement.Domain.Models.UserIdentiy;
using MoviesManagement.Services.Abstractions;
using System.Threading.Tasks;

namespace Movies.ItAcademy.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(IUserService service, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _service = service;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(Register register)
        {
            if (register == null)
                return BadRequest();

            var user = new AppUser { FirstName = register.FirstName, LastName = register.LastName, Email = register.Email, UserName = register.UserName };

            var result = await _userManager.CreateAsync(user, register.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, RolesEnum.User.ToString());
                return Ok(result);
            }

            return BadRequest();

        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                var result = await _userManager.CheckPasswordAsync(user, password);
                if (result)
                {
                    var roleName = await _userManager.GetRolesAsync(user);
                    var token = _service.AuthenticateAsync(userName, roleName[0]);
                    if (token == null)
                        return BadRequest();

                    return Ok(token);
                }
            }

            return BadRequest();
        }
    }
}
