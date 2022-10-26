using AutoMapper;
using MicroServices.Dtos;
using MicroServices.Models;

namespace MicroServices.Profiles;

public class PlatformProfiles:Profile
{
	public PlatformProfiles()
	{
		CreateMap<Platform, PlatformReadDto>();
		CreateMap<PlatformCreateDto, Platform>();
	}
}

