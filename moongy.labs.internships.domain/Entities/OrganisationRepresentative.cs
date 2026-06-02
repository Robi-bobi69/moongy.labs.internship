namespace moongy.labs.internships.Domain.Entities
{
    public class OrganizationRepresentative
    {
        public int OrganizationRepresentativeId { get; set; }
        public int OrganizationId { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}