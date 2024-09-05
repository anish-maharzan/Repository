using Respository.API.Models.Domain;

namespace Respository.API.Repositories.Abstraction
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudentById();
        Task<Student> AddStudent();
        Task<Student> UpdateStudent();
        Task<Student> DeleteStudent();
    }
}
