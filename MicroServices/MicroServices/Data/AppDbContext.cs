using MicroServices.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroServices.Data;

public class AppDbContext:DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> opt):base(opt)
	{

	}

	public DbSet<Platform> Platforms { get; set; }
}

