
using moongy.labs.internships.Domain.Entities;


namespace Moongy.Labs.Internships.DataAccess.Repositories
{
    public class InternshipRepository : IInternshipRepository
    {
        public IEnumerable<Internship> GetAll()
        {
            return new List<Internship>
            {
                new Internship
                {
                    Id = 1,
                    Title = "Backend Intern",
                    Company = "Moongy",
                    Description = "C# internship",
                   
                }
            };
        }
    }
}