using Microsoft.AspNetCore.Mvc;

namespace MarsRover.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoverController : ControllerBase
    {
        public IActionResult Move()
        {
            return null;
        }
        
        public IActionResult Turn()
        {
            return null;
        }
    }
}
