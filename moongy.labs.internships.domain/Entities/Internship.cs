using System;
using System.Collections.Generic;
using System.Text;

namespace moongy.labs.internships.Domain.Entities
{
    public class Internship
    {
        public int InternshipId { get; set; }
        public int OrganizationId { get; set; }
        public int PartnerId { get; set; }
        public int SchoolId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
