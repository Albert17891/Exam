using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.ManagementPanel.Models;
using System.Threading.Tasks;

namespace Movies.ManagementPanel.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesManagerController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesManagerController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RolesModel rolesModel)
        {
            if (rolesModel != null)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = rolesModel.RoleName });
            }

            return RedirectToAction("Index");
        }
    }
}
