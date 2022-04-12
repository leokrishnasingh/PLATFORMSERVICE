using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;
        public PlatformsController(IPlatformRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// api/platforms/Getallplatforms
        [HttpGet("")]
        public ActionResult<IEnumerable<PlatformReadDto>> GetAllPlatforms()
        {
            Console.WriteLine("--> Get all platforms, this shows that we are in the Action method");
            var platformItem = _repository.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            var platformItem = _repository.GetPlatformById(id);
            if(platformItem != null)
            {
                return Ok(_mapper.Map<PlatformReadDto>(platformItem));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlateform(PlatformCreateDto platformCreateDto)
        {
            var platformToAdd  = _mapper.Map<Platform>(platformCreateDto);
            _repository.CreatePlatform(platformToAdd);
            _repository.SaveChanges();
            var addedPlatform =  _mapper.Map<PlatformReadDto>(platformToAdd);
            return CreatedAtRoute(nameof(GetPlatformById), new {addedPlatform.Id,addedPlatform});
        } 

    }
}