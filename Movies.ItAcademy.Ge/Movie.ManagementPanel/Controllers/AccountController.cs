using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movies.ManagementPanel.Models;
using MoviesManagement.Domain.Enum;
using MoviesManagement.Domain.Models.UserIdentiy;
using System.Threading.Tasks;

namespace Movies.ManagementPanel.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signinManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //[Route("Register")]
        public async Task<IActionResult> Register(Register register)
        {
            if (!ModelState.IsValid)
                return View();

            var user = new AppUser() { UserName = register.UserName, FirstName = register.FirstName, LastName = register.LastName, Email = register.Email };
            var result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Error occurrences in Register Time");
                return View();
            }
            await _userManager.AddToRoleAsync(user, RolesEnum.User.ToString());
            return RedirectToAction("Login");

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null)
            {
                var result = await _signinManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    var a = _signinManager.IsSignedIn(User);
                    var name = User.Identity.Name;
                   

                    return RedirectToAction("Privacy", "Home");
                }
            }
            ModelState.AddModelError("", "Username or password is incorrect");

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
