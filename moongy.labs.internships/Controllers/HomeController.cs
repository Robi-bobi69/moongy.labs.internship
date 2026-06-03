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

        [HttpGet("TestDb")]
        public IActionResult TestDb()
        {
            var canConnect = _context.Database.CanConnect();
            return Ok($"Database connected: {canConnect}");
        }

        [HttpGet("GetInternships")]
        public IActionResult GetInternships()
        {
            var internships = _context.Mentor.ToList();
            return Ok(internships);
        }
    }
}
