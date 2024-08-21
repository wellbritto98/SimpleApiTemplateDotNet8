using SimpleApiTemplateDotNet8.Models.Base;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SimpleApiTemplateDotNet8.Services.GenericService
{
    public interface IGenericService<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(params object[] keyValues);
        Task<IEnumerable<T>> FindAsync(string json);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(params object[] keyValues);
    }
}
