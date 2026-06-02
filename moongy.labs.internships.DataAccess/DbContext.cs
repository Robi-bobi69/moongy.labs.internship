using Microsoft.EntityFrameworkCore;
using moongy.labs.internships.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace moongy.labs.internships.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Intern> Interns { get; set; }
        public DbSet<Internship> Internships { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Organization> Organisations { get; set; }
        public DbSet<OrganizationRepresentative> OrganisationRepresentatives { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<PartnerRepresentative> PartnerRepresentatives { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<SchoolRepresentative> SchoolRepresentatives { get; set; }
    }
}
