using SimpleApiTemplateDotNet8.Models.Base;
using System.Threading.Tasks;
using System.Collections.Generic;
using SimpleApiTemplateDotNet8.Repository.GenericRepository;

namespace SimpleApiTemplateDotNet8.Services.GenericService
{
    public class GenericService<T> : IGenericService<T> where T : BaseEntity
    {
        private readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(params object[] keyValues)
        {
            return await _repository.GetByIdAsync(keyValues);
        }

        public async Task<IEnumerable<T>> FindAsync(string json)
        {
            return await _repository.FindAsync(json);
        }

        public async Task<T> AddAsync(T entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(params object[] keyValues)
        {
            await _repository.DeleteAsync(keyValues);
        }
    }
}
