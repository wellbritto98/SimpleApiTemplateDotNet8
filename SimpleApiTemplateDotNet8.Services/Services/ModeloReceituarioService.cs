using SimpleApiTemplateDotNet8.Models;
using SimpleApiTemplateDotNet8.Repository.Interfaces;
using SimpleApiTemplateDotNet8.Services.GenericService;
using SimpleApiTemplateDotNet8.Services.Interfaces;

namespace SimpleApiTemplateDotNet8.Services
{
    public class ModeloReceituarioService : GenericService<ModeloReceituario>, IModeloReceituarioService
    {
        private readonly IModeloReceituarioRepository _Repository;

        public ModeloReceituarioService(IModeloReceituarioRepository Repository) : base(Repository)
        {
            _Repository = Repository;
        }
    }
}
