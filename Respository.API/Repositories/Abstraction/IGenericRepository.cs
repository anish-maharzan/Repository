﻿namespace Respository.API.Repositories.Abstraction
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T?> UpdateAsync(int id, T entity);
        Task<T?> DeleteAsync(int id);
    }
}
