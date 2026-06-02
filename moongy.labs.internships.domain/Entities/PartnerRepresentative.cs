namespace moongy.labs.internships.Domain.Entities
{
    public class PartnerRepresentative
    {
        public int PartnerRepId { get; set; }
        public int PartnerId { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}