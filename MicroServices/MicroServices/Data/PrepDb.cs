﻿namespace MicroServices.Data;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using (var serviceScope=app.ApplicationServices.CreateScope())
        {
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
        }
    }

    private static void SeedData(AppDbContext context)
    {
        if (!context.Platforms.Any())
        {
            Console.WriteLine("--> Seedind Data ...");
            context.Platforms.AddRange(
                new Models.Platform() { Name="Dot Net",Publisher="Microsoft",Cost="Free"},
                new Models.Platform() { Name="SQL Server Express",Publisher="Microsoft",Cost="Free"},
                new Models.Platform() { Name="Kubernetes",Publisher="Cloud Native Computing Foundation",Cost="Free"}
                );

            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("We already have data");
        }
    }
}

