using SimpleApiTemplateDotNet8.Models;
using SimpleApiTemplateDotNet8.Repository.Interfaces;
using SimpleApiTemplateDotNet8.Services.GenericService;
using SimpleApiTemplateDotNet8.Services.Interfaces;

namespace SimpleApiTemplateDotNet8.Services
{
    public class ExampleService : GenericService<ExampleEntity>, IExampleService
    {
        private readonly IExampleRepository _exampleRepository;

        public ExampleService(IExampleRepository exampleRepository) : base(exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }
    }
}
