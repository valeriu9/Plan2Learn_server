using BookingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResourcesController : ControllerBase
    {
        ResourceService resources = new ResourceService();

        [HttpGet("~/get-resources")]
        public IActionResult GetAllResources()
        {
            return Ok(resources.GetAllResources());
        }
    }
}
