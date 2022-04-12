using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;

namespace PlatformService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IPlatformRepo _platformRepo;
        public TestController(IPlatformRepo platformRepo)
        {
            _platformRepo = platformRepo;
        }

        [HttpGet(Name = "GetAllPlatforms")]
        public IActionResult GetAllPlatforms()
        {
            return Ok("working fine");
            //return Ok(_platformRepo.GetAllPlatforms());
        }
    }
}