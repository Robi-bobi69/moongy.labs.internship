using moongy.labs.internships.Domain.Entities;
using Moongy.Labs.Internships.DataAccess.Repositories;

namespace Moongy.Labs.Internships.Business.Services
{
    public class InternshipService : IInternshipService
    {
        private readonly IInternshipRepository _repository;

        public InternshipService(IInternshipRepository repository)
        {
            _repository = repository;
        }

        // ── Internship ────────────────────────────────────────────────────────

        public IEnumerable<Internship> GetAllInternships()
            => _repository.GetAll();

        public Internship? GetInternshipById(int id)
        {
            ValidateId(id);
            return _repository.GetById(id);
        }

        public Internship CreateInternship(Internship internship)
        {
            if (string.IsNullOrWhiteSpace(internship.Description))
                throw new ArgumentException("Internship description is required.");
            if (internship.OrganizationId <= 0)
                throw new ArgumentException("A valid OrganizationId is required.");
            if (internship.SchoolId <= 0)
                throw new ArgumentException("A valid SchoolId is required.");

            return _repository.Create(internship);
        }

        public Internship? UpdateInternship(int id, Internship internship)
        {
            ValidateId(id);
            if (string.IsNullOrWhiteSpace(internship.Description))
                throw new ArgumentException("Internship description is required.");

            return _repository.Update(id, internship);
        }

        public bool DeleteInternship(int id)
        {
            ValidateId(id);
            return _repository.Delete(id);
        }

        // ── Intern ────────────────────────────────────────────────────────────

        public IEnumerable<Intern> GetAllInterns()
            => _repository.GetAllInterns();

        public Intern? GetInternById(int id)
        {
            ValidateId(id);
            return _repository.GetInternById(id);
        }

        public Intern CreateIntern(Intern intern)
        {
            if (string.IsNullOrWhiteSpace(intern.FirstName))
                throw new ArgumentException("Intern first name is required.");
            if (string.IsNullOrWhiteSpace(intern.LastName))
                throw new ArgumentException("Intern last name is required.");
            if (intern.SchoolId <= 0)
                throw new ArgumentException("A valid SchoolId is required.");

            return _repository.CreateIntern(intern);
        }

        public Intern? UpdateIntern(int id, Intern intern)
        {
            ValidateId(id);
            if (string.IsNullOrWhiteSpace(intern.FirstName))
                throw new ArgumentException("Intern first name is required.");
            if (string.IsNullOrWhiteSpace(intern.LastName))
                throw new ArgumentException("Intern last name is required.");

            return _repository.UpdateIntern(id, intern);
        }

        public bool DeleteIntern(int id)
        {
            ValidateId(id);
            return _repository.DeleteIntern(id);
        }

        // ── Interview ─────────────────────────────────────────────────────────

        public IEnumerable<Interview> GetAllInterviews()
            => _repository.GetAllInterviews();

        public Interview? GetInterviewById(int id)
        {
            ValidateId(id);
            return _repository.GetInterviewById(id);
        }

        public Interview CreateInterview(Interview interview)
        {
            if (interview.InternId <= 0)
                throw new ArgumentException("A valid InternId is required.");
            if (interview.MentorId <= 0)
                throw new ArgumentException("A valid MentorId is required.");
            if (interview.InterviewDate == default)
                throw new ArgumentException("A valid InterviewDate is required.");

            return _repository.CreateInterview(interview);
        }

        public Interview? UpdateInterview(int id, Interview interview)
        {
            ValidateId(id);
            if (interview.InterviewDate == default)
                throw new ArgumentException("A valid InterviewDate is required.");

            return _repository.UpdateInterview(id, interview);
        }

        public bool DeleteInterview(int id)
        {
            ValidateId(id);
            return _repository.DeleteInterview(id);
        }

        // ── Mentor ────────────────────────────────────────────────────────────

        public IEnumerable<Mentor> GetAllMentors()
            => _repository.GetAllMentors();

        public Mentor? GetMentorById(int id)
        {
            ValidateId(id);
            return _repository.GetMentorById(id);
        }

        public Mentor CreateMentor(Mentor mentor)
        {
            if (string.IsNullOrWhiteSpace(mentor.FirstName))
                throw new ArgumentException("Mentor first name is required.");
            if (string.IsNullOrWhiteSpace(mentor.LastName))
                throw new ArgumentException("Mentor last name is required.");
            if (mentor.OrganizationId <= 0)
                throw new ArgumentException("A valid OrganizationId is required.");

            return _repository.CreateMentor(mentor);
        }

        public Mentor? UpdateMentor(int id, Mentor mentor)
        {
            ValidateId(id);
            if (string.IsNullOrWhiteSpace(mentor.FirstName))
                throw new ArgumentException("Mentor first name is required.");
            if (string.IsNullOrWhiteSpace(mentor.LastName))
                throw new ArgumentException("Mentor last name is required.");

            return _repository.UpdateMentor(id, mentor);
        }

        public bool DeleteMentor(int id)
        {
            ValidateId(id);
            return _repository.DeleteMentor(id);
        }

        // ── Organization ──────────────────────────────────────────────────────

        public IEnumerable<Organization> GetAllOrganizations()
            => _repository.GetAllOrganizations();

        public Organization? GetOrganizationById(int id)
        {
            ValidateId(id);
            return _repository.GetOrganizationById(id);
        }

        public Organization CreateOrganization(Organization organization)
        {
            if (string.IsNullOrWhiteSpace(organization.Name))
                throw new ArgumentException("Organization name is required.");

            return _repository.CreateOrganization(organization);
        }

        public Organization? UpdateOrganization(int id, Organization organization)
        {
            ValidateId(id);
            if (string.IsNullOrWhiteSpace(organization.Name))
                throw new ArgumentException("Organization name is required.");

            return _repository.UpdateOrganization(id, organization);
        }

        public bool DeleteOrganization(int id)
        {
            ValidateId(id);
            return _repository.DeleteOrganization(id);
        }

        // ── OrganizationRepresentative ────────────────────────────────────────

        public IEnumerable<OrganizationRepresentative> GetAllOrganizationRepresentatives()
            => _repository.GetAllOrganizationRepresentatives();

        public OrganizationRepresentative? GetOrganizationRepresentativeById(int id)
        {
            ValidateId(id);
            return _repository.GetOrganizationRepresentativeById(id);
        }

        public OrganizationRepresentative CreateOrganizationRepresentative(OrganizationRepresentative rep)
        {
            if (string.IsNullOrWhiteSpace(rep.FirstName))
                throw new ArgumentException("First name is required.");
            if (string.IsNullOrWhiteSpace(rep.LastName))
                throw new ArgumentException("Last name is required.");
            if (rep.OrganizationId <= 0)
                throw new ArgumentException("A valid OrganizationId is required.");

            return _repository.CreateOrganizationRepresentative(rep);
        }

        public OrganizationRepresentative? UpdateOrganizationRepresentative(int id, OrganizationRepresentative rep)
        {
            ValidateId(id);
            if (string.IsNullOrWhiteSpace(rep.FirstName))
                throw new ArgumentException("First name is required.");
            if (string.IsNullOrWhiteSpace(rep.LastName))
                throw new ArgumentException("Last name is required.");

            return _repository.UpdateOrganizationRepresentative(id, rep);
        }

        public bool DeleteOrganizationRepresentative(int id)
        {
            ValidateId(id);
            return _repository.DeleteOrganizationRepresentative(id);
        }

        // ── Partner ───────────────────────────────────────────────────────────

        public IEnumerable<Partner> GetAllPartners()
            => _repository.GetAllPartners();

        public Partner? GetPartnerById(int id)
        {
            ValidateId(id);
            return _repository.GetPartnerById(id);
        }

        public Partner CreatePartner(Partner partner)
        {
            if (string.IsNullOrWhiteSpace(partner.Name))
                throw new ArgumentException("Partner name is required.");

            return _repository.CreatePartner(partner);
        }

        public Partner? UpdatePartner(int id, Partner partner)
        {
            ValidateId(id);
            if (string.IsNullOrWhiteSpace(partner.Name))
                throw new ArgumentException("Partner name is required.");

            return _repository.UpdatePartner(id, partner);
        }

        public bool DeletePartner(int id)
        {
            ValidateId(id);
            return _repository.DeletePartner(id);
        }

        // ── PartnerRepresentative ─────────────────────────────────────────────

        public IEnumerable<PartnerRepresentative> GetAllPartnerRepresentatives()
            => _repository.GetAllPartnerRepresentatives();

        public PartnerRepresentative? GetPartnerRepresentativeById(int id)
        {
            ValidateId(id);
            return _repository.GetPartnerRepresentativeById(id);
        }

        public PartnerRepresentative CreatePartnerRepresentative(PartnerRepresentative rep)
        {
            if (string.IsNullOrWhiteSpace(rep.FirstName))
                throw new ArgumentException("First name is required.");
            if (string.IsNullOrWhiteSpace(rep.LastName))
                throw new ArgumentException("Last name is required.");
            if (rep.PartnerId <= 0)
                throw new ArgumentException("A valid PartnerId is required.");

            return _repository.CreatePartnerRepresentative(rep);
        }

        public PartnerRepresentative? UpdatePartnerRepresentative(int id, PartnerRepresentative rep)
        {
            ValidateId(id);
            if (string.IsNullOrWhiteSpace(rep.FirstName))
                throw new ArgumentException("First name is required.");
            if (string.IsNullOrWhiteSpace(rep.LastName))
                throw new ArgumentException("Last name is required.");

            return _repository.UpdatePartnerRepresentative(id, rep);
        }

        public bool DeletePartnerRepresentative(int id)
        {
            ValidateId(id);
            return _repository.DeletePartnerRepresentative(id);
        }

        // ── School ────────────────────────────────────────────────────────────

        public IEnumerable<School> GetAllSchools()
            => _repository.GetAllSchools();

        public School? GetSchoolById(int id)
        {
            ValidateId(id);
            return _repository.GetSchoolById(id);
        }

        public School CreateSchool(School school)
        {
            if (string.IsNullOrWhiteSpace(school.Name))
                throw new ArgumentException("School name is required.");

            return _repository.CreateSchool(school);
        }

        public School? UpdateSchool(int id, School school)
        {
            ValidateId(id);
            if (string.IsNullOrWhiteSpace(school.Name))
                throw new ArgumentException("School name is required.");

            return _repository.UpdateSchool(id, school);
        }

        public bool DeleteSchool(int id)
        {
            ValidateId(id);
            return _repository.DeleteSchool(id);
        }

        // ── SchoolRepresentative ──────────────────────────────────────────────

        public IEnumerable<SchoolRepresentative> GetAllSchoolRepresentatives()
            => _repository.GetAllSchoolRepresentatives();

        public SchoolRepresentative? GetSchoolRepresentativeById(int id)
        {
            ValidateId(id);
            return _repository.GetSchoolRepresentativeById(id);
        }

        public SchoolRepresentative CreateSchoolRepresentative(SchoolRepresentative rep)
        {
            if (string.IsNullOrWhiteSpace(rep.FirstName))
                throw new ArgumentException("First name is required.");
            if (string.IsNullOrWhiteSpace(rep.LastName))
                throw new ArgumentException("Last name is required.");
            if (rep.SchoolId <= 0)
                throw new ArgumentException("A valid SchoolId is required.");

            return _repository.CreateSchoolRepresentative(rep);
        }

        public SchoolRepresentative? UpdateSchoolRepresentative(int id, SchoolRepresentative rep)
        {
            ValidateId(id);
            if (string.IsNullOrWhiteSpace(rep.FirstName))
                throw new ArgumentException("First name is required.");
            if (string.IsNullOrWhiteSpace(rep.LastName))
                throw new ArgumentException("Last name is required.");

            return _repository.UpdateSchoolRepresentative(id, rep);
        }

        public bool DeleteSchoolRepresentative(int id)
        {
            ValidateId(id);
            return _repository.DeleteSchoolRepresentative(id);
        }

        // ── Private helpers ───────────────────────────────────────────────────

        private static void ValidateId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID must be a positive number.");
        }
    }
}
