using Respository.API.Models.Domain;
using Respository.API.Repositories.Abstraction;
using Respository.API.Services.Abstraction;

namespace Respository.API.Services
{
    public class StudentService : IStudentService
    {
        private readonly IGenericRepository<Student> _studentRepository;

        public StudentService(IGenericRepository<Student> studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student> AddAsync(Student entity)
        {
            return await _studentRepository.AddAsync(entity);
        }

        public async Task<Student?> UpdateAsync(int id, Student entity)
        {
            return await _studentRepository.UpdateAsync(id, entity);
        }

        public async Task<Student?> DeleteAsync(int id)
        {
            return await _studentRepository.DeleteAsync(id);
        }
    }
}
