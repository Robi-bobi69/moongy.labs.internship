
using Microsoft.EntityFrameworkCore;
using moongy.labs.internships.DataAccess;
using moongy.labs.internships.Domain.Entities;


namespace Moongy.Labs.Internships.DataAccess.Repositories
{
    public class InternshipRepository : IInternshipRepository
    {
        private readonly AppDbContext _context;

        public InternshipRepository(AppDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Internship> GetAll()
        {
            return _context.Internship.ToList();
        }
    }
}