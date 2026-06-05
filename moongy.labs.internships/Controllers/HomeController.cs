using Microsoft.AspNetCore.Mvc;
using moongy.labs.internships.DataAccess;
using moongy.labs.internships.Domain.Entities;

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

        //ADDING

        [HttpPost("AddIntern")]
        public IActionResult AddIntern([FromBody] Intern intern)
        {
            _context.Intern.Add(intern);
            _context.SaveChanges();
            return Ok(intern);
        }

        [HttpPost("AddInternship")]
        public IActionResult AddInternship([FromBody] Internship internship)
        {
            _context.Internship.Add(internship);
            _context.SaveChanges();
            return Ok(internship);
        }

        [HttpPost("AddInterview")]
        public IActionResult AddInterview([FromBody] Interview interview)
        {
            _context.Interview.Add(interview);
            _context.SaveChanges();
            return Ok(interview);
        }

        [HttpPost("AddMentor")]
        public IActionResult AddMentor([FromBody] Mentor mentor)
        {
            _context.Mentor.Add(mentor);
            _context.SaveChanges();
            return Ok(mentor);
        }

        [HttpPost("AddOrganization")]
        public IActionResult AddOrganization([FromBody] Organization organization)
        {
            _context.Organization.Add(organization);
            _context.SaveChanges();
            return Ok(organization);
        }

        [HttpPost("AddOrganizationRepresentative")]
        public IActionResult AddOrganizationRepresentative([FromBody] OrganizationRepresentative rep)
        {
            _context.OrganizationRepresentative.Add(rep);
            _context.SaveChanges();
            return Ok(rep);
        }

        [HttpPost("AddPartner")]
        public IActionResult AddPartner([FromBody] Partner partner)
        {
            _context.Partner.Add(partner);
            _context.SaveChanges();
            return Ok(partner);
        }

        [HttpPost("AddPartnerRepresentative")]
        public IActionResult AddPartnerRepresentative([FromBody] PartnerRepresentative rep)
        {
            _context.PartnerRepresentative.Add(rep);
            _context.SaveChanges();
            return Ok(rep);
        }

        [HttpPost("AddSchool")]
        public IActionResult AddSchool([FromBody] School school)
        {
            _context.School.Add(school);
            _context.SaveChanges();
            return Ok(school);
        }

        [HttpPost("AddSchoolRepresentative")]
        public IActionResult AddSchoolRepresentative([FromBody] SchoolRepresentative rep)
        {
            _context.SchoolRepresentative.Add(rep);
            _context.SaveChanges();
            return Ok(rep);
        }
    }
}