using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Movies.ManagementPanel.Models.User;
using MoviesManagement.Domain.Models.UserIdentiy;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.ManagementPanel.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("User")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManger;
        private readonly ILogger<UserController> _logger;


        public UserController(UserManager<AppUser> userManager, ILogger<UserController> logger)
        {
            _userManger = userManager;
            _logger = logger;
        }



        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _userManger.Users.ToListAsync();
            return View(users.Adapt<List<UserModel>>());
        }

        [HttpGet("{name}")]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(string name)
        {
            try
            {
                var user = await _userManger.Users.SingleOrDefaultAsync(x => x.UserName == name);
                return View(user.Adapt<UserModel>());
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Failed in UpdateUser");
                throw;
            }

        }

        [HttpPost]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserModel model)
        {

            var user = await _userManger.FindByIdAsync(model.Id);


            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.UserName = model.UserName;

            try
            {
                var result = await _userManger.UpdateAsync(user);

                if (result.Succeeded)
                {

                    return RedirectToAction("Index");
                }


            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);

            }
            return View();
        }

        [HttpDelete("{name}")]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string name)
        {
            var user = await _userManger.Users.SingleOrDefaultAsync(x => x.UserName == name);
            var myUser = new AppUser
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email
            };
            try
            {
                await _userManger.DeleteAsync(user);
                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);

            }
            return View();
        }

    }
}
