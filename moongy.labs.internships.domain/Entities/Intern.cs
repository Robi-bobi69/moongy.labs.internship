namespace moongy.labs.internships.Domain.Entities
{
    public class Intern
    {
        public int InternId { get; set; }
        public int SchoolId { get; set; }
        public int InternshipId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}