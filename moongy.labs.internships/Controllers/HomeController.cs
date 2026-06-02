using Microsoft.AspNetCore.Mvc;

namespace moongy.labs.internships.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet("GetInt")]
        public int Get()
        {
            return 100;
        }
        [HttpGet ("GetInt2")]
        public int get2()
        {
            return 200;

        }
    }
}
