using Moongy.Labs.Internships.DataAccess.Repositories;
using moongy.labs.internships.Domain.Entities;

namespace Moongy.Labs.Internships.Business.Services
{
    public class InternshipService : IInternshipService
    {
        private readonly IInternshipRepository _repository;

        public InternshipService(IInternshipRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Internship> GetAll()
        {
            return _repository.GetAll();
        }
    }
}