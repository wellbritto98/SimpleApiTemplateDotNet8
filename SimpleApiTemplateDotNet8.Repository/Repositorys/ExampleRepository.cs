using SimpleApiTemplateDotNet8.Data;
using SimpleApiTemplateDotNet8.Models;
using SimpleApiTemplateDotNet8.Repository.GenericRepository;
using SimpleApiTemplateDotNet8.Repository.Interfaces;

namespace SimpleApiTemplateDotNet8.Repository.Repositorys;

public class ExampleRepository : GenericRepository<ExampleEntity>, IExampleRepository
{
    public ExampleRepository(DataContext context) : base(context)
    {
    }
}