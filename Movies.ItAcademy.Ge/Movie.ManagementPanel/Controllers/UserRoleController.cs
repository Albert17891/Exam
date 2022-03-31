using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.ManagementPanel.Models;
using MoviesManagement.Domain.Models.UserIdentiy;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.ManagementPanel.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserRoleController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRoleController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            List<UserRolesModel> userRolesModels = new List<UserRolesModel>();

            foreach (var user in users)
            {
                var userRolesModel = new UserRolesModel()
                {
                    Id = user.Id,
                    FirstName = user.UserName,
                    Roles = await GetUserRoles(user)
                };
                userRolesModels.Add(userRolesModel);
            }

            return View(userRolesModels);
        }

        private async Task<List<string>> GetUserRoles(AppUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }

        public async Task<IActionResult> Manage(string userId)
        {


            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return View("Not Found");

            ViewBag.UserName = user.UserName;

            var roleModel = new List<RolesModel>();

            foreach (var role in _roleManager.Roles)
            {
                var userRole = new RolesModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                if (await _userManager.IsInRoleAsync(user, userRole.RoleName))
                {
                    userRole.Selected = true;
                }
                else
                {
                    userRole.Selected = false;
                }
                roleModel.Add(userRole);
            }
            return View(roleModel);
        }

        [HttpPost]
        public async Task<IActionResult> Manage(List<RolesModel> userRoles, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return View();

            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot Remove");
                return View(userRoles);
            }
            var Addresult = await _userManager.AddToRolesAsync(user, userRoles.AsQueryable().Where(x => x.Selected == true).Select(x => x.RoleName));
            if (!Addresult.Succeeded)
            {
                ModelState.AddModelError("", "Cannot Add");
                return View(userRoles);
            }

            return RedirectToAction("Index");
        }
    }
}
