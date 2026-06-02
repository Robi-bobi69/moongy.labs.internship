namespace moongy.labs.internships.Domain.Entities
{
    public class SchoolRepresentative
    {
        public int SchoolRepId { get; set; }
        public int SchoolId { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}