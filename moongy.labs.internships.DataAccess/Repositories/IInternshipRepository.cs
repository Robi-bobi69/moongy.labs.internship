using moongy.labs.internships.Domain.Entities;

namespace Moongy.Labs.Internships.DataAccess.Repositories
{
    public interface IInternshipRepository
    {
        IEnumerable<Internship> GetAll();
    }
}