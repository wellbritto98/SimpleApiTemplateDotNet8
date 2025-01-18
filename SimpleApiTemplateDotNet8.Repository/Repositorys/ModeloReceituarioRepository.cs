using SimpleApiTemplateDotNet8.Data;
using SimpleApiTemplateDotNet8.Models;
using SimpleApiTemplateDotNet8.Repository.GenericRepository;
using SimpleApiTemplateDotNet8.Repository.Interfaces;

namespace SimpleApiTemplateDotNet8.Repository.Repositorys;

public class ModeloReceituarioRepository : GenericRepository<ModeloReceituario>, IModeloReceituarioRepository
{
    public ModeloReceituarioRepository(DataContext context) : base(context)
    {
    }
}
