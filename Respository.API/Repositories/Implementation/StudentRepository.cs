using Microsoft.EntityFrameworkCore;
using Respository.API.Data;
using Respository.API.Models.Domain;
using Respository.API.Repositories.Abstraction;

namespace Respository.API.Repositories.Implementation
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly ApplicationDbContext context;

        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public Task<Student> AddStudent()
        {
            throw new NotImplementedException();
        }

        public Task<Student> DeleteStudent()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await context.Students
                 .Select(s => new Student
                 {
                     StudentID = s.StudentID,
                     FirstName = s.FirstName,
                     MiddleName = s.MiddleName,
                     LastName = s.LastName
                 }).ToListAsync();
        }

        public Task<Student> GetStudentById()
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateStudent()
        {
            throw new NotImplementedException();
        }
    }
}
