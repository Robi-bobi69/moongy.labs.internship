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
        public DbSet<Intern> Intern { get; set; }
        public DbSet<Internship> Internship { get; set; }
        public DbSet<Interview> Interview { get; set; }
        public DbSet<Mentor> Mentor { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<OrganizationRepresentative> OrganizationRepresentative { get; set; }
        public DbSet<Partner> Partner { get; set; }
        public DbSet<PartnerRepresentative> PartnerRepresentative { get; set; }
        public DbSet<School> School { get; set; }
        public DbSet<SchoolRepresentative> SchoolRepresentative { get; set; }
    }

}
