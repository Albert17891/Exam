﻿using MicroServices.Models;

namespace MicroServices.Data;

public interface IPlatformRepo
{
    bool SaveChanges();
    IEnumerable<Platform> GetAllPlatforms();

    Platform GetPlatformById(int id);

    void CreatePlatform(Platform platform);
}

