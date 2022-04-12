using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            //source -> destination
            CreateMap<Platform , PlatformReadDto>();
            CreateMap<PlatformCreateDto,Platform>();
        }
        
    }
}