using AutoMapper;
using SimpleApiTemplateDotNet8.Models;
using SimpleApiTemplateDotNet8.Repository.Interfaces;
using SimpleApiTemplateDotNet8.Web.Controllers.GenericController;
using SimpleApiTemplateDotNet8.Data.Dtos;
using SimpleApiTemplateDotNet8.Services.Interfaces;

namespace SimpleApiTemplateDotNet8.Web.Controllers;
public class ModeloReceituarioQueryParams
{
    public int Id { get; set; }
}
public class ModeloReceituarioController : GenericController<ModeloReceituario, InsertModeloReceituarioDto, ReadModeloReceituarioDto, UpdateModeloReceituarioDto, ModeloReceituarioQueryParams>
{
    public ModeloReceituarioController(IModeloReceituarioService service, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(service, mapper, httpContextAccessor)
    {

    }

}
