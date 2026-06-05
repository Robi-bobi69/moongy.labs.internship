using Microsoft.AspNetCore.Mvc;
using moongy.labs.internships.DataAccess;

namespace moongy.labs.internships.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
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

        [HttpGet("GetInterns")]
        public IActionResult GetInterns()
        {
            return Ok(_context.Intern.ToList());
        }

        [HttpGet("GetInternships")]
        public IActionResult GetInternships()
        {
            return Ok(_context.Internship.ToList());
        }

        [HttpGet("GetInterviews")]
        public IActionResult GetInterviews()
        {
            return Ok(_context.Interview.ToList());
        }

        [HttpGet("GetMentor")]
        public IActionResult GetMentor()
        {
            return Ok(_context.Mentor.ToList());
        }

        [HttpGet("GetOrganizations")]
        public IActionResult GetOrganizations()
        {
            return Ok(_context.Organization.ToList());
        }

        [HttpGet("GetOrganizationRepresentatives")]
        public IActionResult GetOrganizationRepresentatives()
        {
            return Ok(_context.OrganizationRepresentative.ToList());
        }

        [HttpGet("GetPartners")]
        public IActionResult GetPartners()
        {
            return Ok(_context.Partner.ToList());
        }

        [HttpGet("GetPartnerRepresentatives")]
        public IActionResult GetPartnerRepresentatives()
        {
            return Ok(_context.PartnerRepresentative.ToList());
        }

        [HttpGet("GetSchools")]
        public IActionResult GetSchools()
        {
            return Ok(_context.School.ToList());
        }

        [HttpGet("GetSchoolRepresentatives")]
        public IActionResult GetSchoolRepresentatives()
        {
            return Ok(_context.SchoolRepresentative.ToList());
        }
    }
}