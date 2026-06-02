using System;
using System.Collections.Generic;
using System.Text;

namespace moongy.labs.internships.Domain.Entities
{
    public class Internship
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
        
    }
}
