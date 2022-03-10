using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedisAPI.Data;
using RedisAPI.Models;

namespace RedisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repo;

        public PlatformsController(IPlatformRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Platform>> GetAllPlatforms()
        {
            return Ok(_repo.GetAllPlatforms());
        }


        [HttpGet("{id}",Name = "GetPlatforById")]
        public ActionResult<Platform> GetPlatforById(string id)
        {
            var platform = _repo.GetPlatforById(id);

            if (platform != null)
            {
                return Ok(platform);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Platform> Create(Platform plat)
        {
            _repo.CreatePlatform(plat);

            return CreatedAtRoute(nameof(GetPlatforById), new { Id = plat.Id }, plat);
        }
    }
}
