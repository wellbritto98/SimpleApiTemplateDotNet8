
using SimpleApiTemplateDotNet8.Models.Base;

namespace SimpleApiTemplateDotNet8.Repository.GenericRepository;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(string json);
    Task<T> GetByIdAsync(params object[] keyValues);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(params object[] keyValues);

}