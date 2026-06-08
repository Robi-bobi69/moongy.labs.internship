using Microsoft.AspNetCore.Mvc;
using moongy.labs.internships.Domain.Entities;
using Moongy.Labs.Internships.Business.Services;

namespace moongy.labs.internships.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IInternshipService _service;

        public HomeController(IInternshipService service)
        {
            _service = service;
        }

        // GET

        [HttpGet("GetInterns")]
        public IActionResult GetInterns()
            => Ok(_service.GetAllInterns());

        [HttpGet("GetInternships")]
        public IActionResult GetInternships()
            => Ok(_service.GetAllInternships());

        [HttpGet("GetInterviews")]
        public IActionResult GetInterviews()
            => Ok(_service.GetAllInterviews());

        [HttpGet("GetMentor")]
        public IActionResult GetMentor()
            => Ok(_service.GetAllMentors());

        [HttpGet("GetOrganizations")]
        public IActionResult GetOrganizations()
            => Ok(_service.GetAllOrganizations());

        [HttpGet("GetOrganizationRepresentatives")]
        public IActionResult GetOrganizationRepresentatives()
            => Ok(_service.GetAllOrganizationRepresentatives());

        [HttpGet("GetPartners")]
        public IActionResult GetPartners()
            => Ok(_service.GetAllPartners());

        [HttpGet("GetPartnerRepresentatives")]
        public IActionResult GetPartnerRepresentatives()
            => Ok(_service.GetAllPartnerRepresentatives());

        [HttpGet("GetSchools")]
        public IActionResult GetSchools()
            => Ok(_service.GetAllSchools());

        [HttpGet("GetSchoolRepresentatives")]
        public IActionResult GetSchoolRepresentatives()
            => Ok(_service.GetAllSchoolRepresentatives());

        // POST

        [HttpPost("AddIntern")]
        public IActionResult AddIntern([FromBody] Intern intern)
        {
            try { return Ok(_service.CreateIntern(intern)); }
            catch (ArgumentException ex) { return BadRequest(new { message = ex.Message }); }
        }

        [HttpPost("AddInternship")]
        public IActionResult AddInternship([FromBody] Internship internship)
        {
            try { return Ok(_service.CreateInternship(internship)); }
            catch (ArgumentException ex) { return BadRequest(new { message = ex.Message }); }
        }

        [HttpPost("AddInterview")]
        public IActionResult AddInterview([FromBody] Interview interview)
        {
            try { return Ok(_service.CreateInterview(interview)); }
            catch (ArgumentException ex) { return BadRequest(new { message = ex.Message }); }
        }

        [HttpPost("AddMentor")]
        public IActionResult AddMentor([FromBody] Mentor mentor)
        {
            try { return Ok(_service.CreateMentor(mentor)); }
            catch (ArgumentException ex) { return BadRequest(new { message = ex.Message }); }
        }

        [HttpPost("AddOrganization")]
        public IActionResult AddOrganization([FromBody] Organization organization)
        {
            try { return Ok(_service.CreateOrganization(organization)); }
            catch (ArgumentException ex) { return BadRequest(new { message = ex.Message }); }
        }

        [HttpPost("AddOrganizationRepresentative")]
        public IActionResult AddOrganizationRepresentative([FromBody] OrganizationRepresentative rep)
        {
            try { return Ok(_service.CreateOrganizationRepresentative(rep)); }
            catch (ArgumentException ex) { return BadRequest(new { message = ex.Message }); }
        }

        [HttpPost("AddPartner")]
        public IActionResult AddPartner([FromBody] Partner partner)
        {
            try { return Ok(_service.CreatePartner(partner)); }
            catch (ArgumentException ex) { return BadRequest(new { message = ex.Message }); }
        }

        [HttpPost("AddPartnerRepresentative")]
        public IActionResult AddPartnerRepresentative([FromBody] PartnerRepresentative rep)
        {
            try { return Ok(_service.CreatePartnerRepresentative(rep)); }
            catch (ArgumentException ex) { return BadRequest(new { message = ex.Message }); }
        }

        [HttpPost("AddSchool")]
        public IActionResult AddSchool([FromBody] School school)
        {
            try { return Ok(_service.CreateSchool(school)); }
            catch (ArgumentException ex) { return BadRequest(new { message = ex.Message }); }
        }

        [HttpPost("AddSchoolRepresentative")]
        public IActionResult AddSchoolRepresentative([FromBody] SchoolRepresentative rep)
        {
            try { return Ok(_service.CreateSchoolRepresentative(rep)); }
            catch (ArgumentException ex) { return BadRequest(new { message = ex.Message }); }
        }
    }
}
