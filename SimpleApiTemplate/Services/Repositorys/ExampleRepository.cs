using SimpleApiTemplate.Data;
using SimpleApiTemplate.Models;
using SimpleApiTemplate.Services.Interfaces;
using SimpleApiTemplate.Services.Repositorys;
using SimpleApiTemplate.Services.GenericRepository;

namespace SimpleApiTemplate.Services.Repositorys;

public class ExampleRepository : GenericRepository<ExampleEntity>, IExampleRepository
{
    public ExampleRepository(DataContext context) : base(context)
    {
    }
}