using AutoMapper;
using SimpleApiTemplateDotNet8.Models;
using SimpleApiTemplateDotNet8.Repository.Interfaces;
using SimpleApiTemplateDotNet8.Web.Controllers.GenericController;
using SimpleApiTemplateDotNet8.Data.Dtos;
using SimpleApiTemplateDotNet8.Services.Interfaces;

namespace SimpleApiTemplateDotNet8.Web.Controllers;
public class ExampleQueryParams
{
    public int Id { get; set; }
}
public class ExampleController : GenericController<ExampleEntity, InsertExampleDto, ReadExampleDto, UpdateExampleDto, ExampleQueryParams>
{
    public ExampleController(IExampleService service, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(service, mapper, httpContextAccessor)
    {

    }

}