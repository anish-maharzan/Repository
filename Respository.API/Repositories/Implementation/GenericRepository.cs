using Microsoft.EntityFrameworkCore;
using Respository.API.Data;
using Respository.API.Repositories.Abstraction;
namespace Respository.API.Repositories.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbset;

        public GenericRepository(ApplicationDbContext context)
        {
            this._context = context;
            _dbset = _context.Set<T>();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbset.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T?> UpdateAsync(int id, T entity)
        {
            var existingEntity = await GetByIdAsync(id);
            if (existingEntity == null)
            {
                return null;
            }
            _dbset.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T?> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }
            _dbset.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
