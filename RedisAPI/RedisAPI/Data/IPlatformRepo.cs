using RedisAPI.Models;

namespace RedisAPI.Data
{
    public interface IPlatformRepo
    {
        void CreatePlatform(Platform plat);
        Platform? GetPlatforById(string id);
        IEnumerable<Platform?>? GetAllPlatforms();
    }
}
