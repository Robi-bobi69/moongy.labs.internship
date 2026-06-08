using moongy.labs.internships.DataAccess;
using moongy.labs.internships.Domain.Entities;

namespace Moongy.Labs.Internships.DataAccess.Repositories
{
    public class InternshipRepository : IInternshipRepository
    {
        private readonly AppDbContext _context;

        public InternshipRepository(AppDbContext context)
        {
            _context = context;
        }

        // ── Internship ────────────────────────────────────────────────────────

        public IEnumerable<Internship> GetAll()
            => _context.Internship.ToList();

        public Internship? GetById(int id)
            => _context.Internship.Find(id);

        public Internship Create(Internship internship)
        {
            _context.Internship.Add(internship);
            _context.SaveChanges();
            return internship;
        }

        public Internship? Update(int id, Internship updated)
        {
            var existing = _context.Internship.Find(id);
            if (existing is null) return null;

            existing.OrganizationId = updated.OrganizationId;
            existing.PartnerId = updated.PartnerId;
            existing.SchoolId = updated.SchoolId;
            existing.Description = updated.Description;

            _context.SaveChanges();
            return existing;
        }

        public bool Delete(int id)
        {
            var entity = _context.Internship.Find(id);
            if (entity is null) return false;
            _context.Internship.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        // ── Intern ────────────────────────────────────────────────────────────

        public IEnumerable<Intern> GetAllInterns()
            => _context.Intern.ToList();

        public Intern? GetInternById(int id)
            => _context.Intern.Find(id);

        public Intern CreateIntern(Intern intern)
        {
            _context.Intern.Add(intern);
            _context.SaveChanges();
            return intern;
        }

        public Intern? UpdateIntern(int id, Intern updated)
        {
            var existing = _context.Intern.Find(id);
            if (existing is null) return null;

            existing.SchoolId = updated.SchoolId;
            existing.InternshipId = updated.InternshipId;
            existing.FirstName = updated.FirstName;
            existing.LastName = updated.LastName;

            _context.SaveChanges();
            return existing;
        }

        public bool DeleteIntern(int id)
        {
            var entity = _context.Intern.Find(id);
            if (entity is null) return false;
            _context.Intern.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        // ── Interview ─────────────────────────────────────────────────────────

        public IEnumerable<Interview> GetAllInterviews()
            => _context.Interview.ToList();

        public Interview? GetInterviewById(int id)
            => _context.Interview.Find(id);

        public Interview CreateInterview(Interview interview)
        {
            _context.Interview.Add(interview);
            _context.SaveChanges();
            return interview;
        }

        public Interview? UpdateInterview(int id, Interview updated)
        {
            var existing = _context.Interview.Find(id);
            if (existing is null) return null;

            existing.InternshipId = updated.InternshipId;
            existing.InternId = updated.InternId;
            existing.MentorId = updated.MentorId;
            existing.InterviewDate = updated.InterviewDate;

            _context.SaveChanges();
            return existing;
        }

        public bool DeleteInterview(int id)
        {
            var entity = _context.Interview.Find(id);
            if (entity is null) return false;
            _context.Interview.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        // ── Mentor ────────────────────────────────────────────────────────────

        public IEnumerable<Mentor> GetAllMentors()
            => _context.Mentor.ToList();

        public Mentor? GetMentorById(int id)
            => _context.Mentor.Find(id);

        public Mentor CreateMentor(Mentor mentor)
        {
            _context.Mentor.Add(mentor);
            _context.SaveChanges();
            return mentor;
        }

        public Mentor? UpdateMentor(int id, Mentor updated)
        {
            var existing = _context.Mentor.Find(id);
            if (existing is null) return null;

            existing.OrganizationId = updated.OrganizationId;
            existing.FirstName = updated.FirstName;
            existing.LastName = updated.LastName;

            _context.SaveChanges();
            return existing;
        }

        public bool DeleteMentor(int id)
        {
            var entity = _context.Mentor.Find(id);
            if (entity is null) return false;
            _context.Mentor.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        // ── Organization ──────────────────────────────────────────────────────

        public IEnumerable<Organization> GetAllOrganizations()
            => _context.Organization.ToList();

        public Organization? GetOrganizationById(int id)
            => _context.Organization.Find(id);

        public Organization CreateOrganization(Organization organization)
        {
            _context.Organization.Add(organization);
            _context.SaveChanges();
            return organization;
        }

        public Organization? UpdateOrganization(int id, Organization updated)
        {
            var existing = _context.Organization.Find(id);
            if (existing is null) return null;

            existing.Name = updated.Name;

            _context.SaveChanges();
            return existing;
        }

        public bool DeleteOrganization(int id)
        {
            var entity = _context.Organization.Find(id);
            if (entity is null) return false;
            _context.Organization.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        // ── OrganizationRepresentative ────────────────────────────────────────

        public IEnumerable<OrganizationRepresentative> GetAllOrganizationRepresentatives()
            => _context.OrganizationRepresentative.ToList();

        public OrganizationRepresentative? GetOrganizationRepresentativeById(int id)
            => _context.OrganizationRepresentative.Find(id);

        public OrganizationRepresentative CreateOrganizationRepresentative(OrganizationRepresentative rep)
        {
            _context.OrganizationRepresentative.Add(rep);
            _context.SaveChanges();
            return rep;
        }

        public OrganizationRepresentative? UpdateOrganizationRepresentative(int id, OrganizationRepresentative updated)
        {
            var existing = _context.OrganizationRepresentative.Find(id);
            if (existing is null) return null;

            existing.OrganizationId = updated.OrganizationId;
            existing.FirstName = updated.FirstName;
            existing.LastName = updated.LastName;

            _context.SaveChanges();
            return existing;
        }

        public bool DeleteOrganizationRepresentative(int id)
        {
            var entity = _context.OrganizationRepresentative.Find(id);
            if (entity is null) return false;
            _context.OrganizationRepresentative.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        // ── Partner ───────────────────────────────────────────────────────────

        public IEnumerable<Partner> GetAllPartners()
            => _context.Partner.ToList();

        public Partner? GetPartnerById(int id)
            => _context.Partner.Find(id);

        public Partner CreatePartner(Partner partner)
        {
            _context.Partner.Add(partner);
            _context.SaveChanges();
            return partner;
        }

        public Partner? UpdatePartner(int id, Partner updated)
        {
            var existing = _context.Partner.Find(id);
            if (existing is null) return null;

            existing.Name = updated.Name;

            _context.SaveChanges();
            return existing;
        }

        public bool DeletePartner(int id)
        {
            var entity = _context.Partner.Find(id);
            if (entity is null) return false;
            _context.Partner.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        // ── PartnerRepresentative ─────────────────────────────────────────────

        public IEnumerable<PartnerRepresentative> GetAllPartnerRepresentatives()
            => _context.PartnerRepresentative.ToList();

        public PartnerRepresentative? GetPartnerRepresentativeById(int id)
            => _context.PartnerRepresentative.Find(id);

        public PartnerRepresentative CreatePartnerRepresentative(PartnerRepresentative rep)
        {
            _context.PartnerRepresentative.Add(rep);
            _context.SaveChanges();
            return rep;
        }

        public PartnerRepresentative? UpdatePartnerRepresentative(int id, PartnerRepresentative updated)
        {
            var existing = _context.PartnerRepresentative.Find(id);
            if (existing is null) return null;

            existing.PartnerId = updated.PartnerId;
            existing.FirstName = updated.FirstName;
            existing.LastName = updated.LastName;

            _context.SaveChanges();
            return existing;
        }

        public bool DeletePartnerRepresentative(int id)
        {
            var entity = _context.PartnerRepresentative.Find(id);
            if (entity is null) return false;
            _context.PartnerRepresentative.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        // ── School ────────────────────────────────────────────────────────────

        public IEnumerable<School> GetAllSchools()
            => _context.School.ToList();

        public School? GetSchoolById(int id)
            => _context.School.Find(id);

        public School CreateSchool(School school)
        {
            _context.School.Add(school);
            _context.SaveChanges();
            return school;
        }

        public School? UpdateSchool(int id, School updated)
        {
            var existing = _context.School.Find(id);
            if (existing is null) return null;

            existing.Name = updated.Name;

            _context.SaveChanges();
            return existing;
        }

        public bool DeleteSchool(int id)
        {
            var entity = _context.School.Find(id);
            if (entity is null) return false;
            _context.School.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        // ── SchoolRepresentative ──────────────────────────────────────────────

        public IEnumerable<SchoolRepresentative> GetAllSchoolRepresentatives()
            => _context.SchoolRepresentative.ToList();

        public SchoolRepresentative? GetSchoolRepresentativeById(int id)
            => _context.SchoolRepresentative.Find(id);

        public SchoolRepresentative CreateSchoolRepresentative(SchoolRepresentative rep)
        {
            _context.SchoolRepresentative.Add(rep);
            _context.SaveChanges();
            return rep;
        }

        public SchoolRepresentative? UpdateSchoolRepresentative(int id, SchoolRepresentative updated)
        {
            var existing = _context.SchoolRepresentative.Find(id);
            if (existing is null) return null;

            existing.SchoolId = updated.SchoolId;
            existing.FirstName = updated.FirstName;
            existing.LastName = updated.LastName;

            _context.SaveChanges();
            return existing;
        }

        public bool DeleteSchoolRepresentative(int id)
        {
            var entity = _context.SchoolRepresentative.Find(id);
            if (entity is null) return false;
            _context.SchoolRepresentative.Remove(entity);
            _context.SaveChanges();
            return true;
        }
    }
}
