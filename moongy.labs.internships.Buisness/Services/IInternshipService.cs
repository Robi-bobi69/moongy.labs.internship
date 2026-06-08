using moongy.labs.internships.Domain.Entities;

namespace Moongy.Labs.Internships.Business.Services
{
    public interface IInternshipService
    {
        // Internship
        IEnumerable<Internship> GetAllInternships();
        Internship? GetInternshipById(int id);
        Internship CreateInternship(Internship internship);
        Internship? UpdateInternship(int id, Internship internship);
        bool DeleteInternship(int id);

        // Intern
        IEnumerable<Intern> GetAllInterns();
        Intern? GetInternById(int id);
        Intern CreateIntern(Intern intern);
        Intern? UpdateIntern(int id, Intern intern);
        bool DeleteIntern(int id);

        // Interview
        IEnumerable<Interview> GetAllInterviews();
        Interview? GetInterviewById(int id);
        Interview CreateInterview(Interview interview);
        Interview? UpdateInterview(int id, Interview interview);
        bool DeleteInterview(int id);

        // Mentor
        IEnumerable<Mentor> GetAllMentors();
        Mentor? GetMentorById(int id);
        Mentor CreateMentor(Mentor mentor);
        Mentor? UpdateMentor(int id, Mentor mentor);
        bool DeleteMentor(int id);

        // Organization
        IEnumerable<Organization> GetAllOrganizations();
        Organization? GetOrganizationById(int id);
        Organization CreateOrganization(Organization organization);
        Organization? UpdateOrganization(int id, Organization organization);
        bool DeleteOrganization(int id);

        // OrganizationRepresentative
        IEnumerable<OrganizationRepresentative> GetAllOrganizationRepresentatives();
        OrganizationRepresentative? GetOrganizationRepresentativeById(int id);
        OrganizationRepresentative CreateOrganizationRepresentative(OrganizationRepresentative rep);
        OrganizationRepresentative? UpdateOrganizationRepresentative(int id, OrganizationRepresentative rep);
        bool DeleteOrganizationRepresentative(int id);

        // Partner
        IEnumerable<Partner> GetAllPartners();
        Partner? GetPartnerById(int id);
        Partner CreatePartner(Partner partner);
        Partner? UpdatePartner(int id, Partner partner);
        bool DeletePartner(int id);

        // PartnerRepresentative
        IEnumerable<PartnerRepresentative> GetAllPartnerRepresentatives();
        PartnerRepresentative? GetPartnerRepresentativeById(int id);
        PartnerRepresentative CreatePartnerRepresentative(PartnerRepresentative rep);
        PartnerRepresentative? UpdatePartnerRepresentative(int id, PartnerRepresentative rep);
        bool DeletePartnerRepresentative(int id);

        // School
        IEnumerable<School> GetAllSchools();
        School? GetSchoolById(int id);
        School CreateSchool(School school);
        School? UpdateSchool(int id, School school);
        bool DeleteSchool(int id);

        // SchoolRepresentative
        IEnumerable<SchoolRepresentative> GetAllSchoolRepresentatives();
        SchoolRepresentative? GetSchoolRepresentativeById(int id);
        SchoolRepresentative CreateSchoolRepresentative(SchoolRepresentative rep);
        SchoolRepresentative? UpdateSchoolRepresentative(int id, SchoolRepresentative rep);
        bool DeleteSchoolRepresentative(int id);
    }
}
