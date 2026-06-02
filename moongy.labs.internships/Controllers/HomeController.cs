using Microsoft.AspNetCore.Mvc;
using moongy.labs.internships.DataAccess;

namespace moongy.labs.internships.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        //testing database
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        //
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
        //
        [HttpGet("TestDb")]
        public IActionResult TestDb()
        {
            var canConnect = _context.Database.CanConnect();
            return Ok(canConnect);
        }
    }
}
