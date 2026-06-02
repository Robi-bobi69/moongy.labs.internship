using moongy.labs.internships.Domain.Entities;

namespace Moongy.Labs.Internships.Business.Services
{
    public interface IInternshipService
    {
        IEnumerable<Internship> GetAll();
    }
}