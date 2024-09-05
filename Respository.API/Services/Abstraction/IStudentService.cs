using Respository.API.Models.Domain;
using Respository.API.Repositories.Abstraction;

namespace Respository.API.Services.Abstraction
{
    public interface IStudentService : IGenericRepository<Student>
    {
    }
}
