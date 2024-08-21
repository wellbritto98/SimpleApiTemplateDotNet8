using AutoMapper;
using SimpleApiTemplateDotNet8.Models;
using SimpleApiTemplateDotNet8.Repository.Interfaces;
using SimpleApiTemplate.Web.Controllers.GenericController;
using SimpleApiTemplateDotNet8.Data.Dtos;
using SimpleApiTemplateDotNet8.Services.Interfaces;

namespace SimpleApiTemplate.Web.Controllers;

public class ExampleController : GenericController<ExampleEntity, InsertExampleDto, ReadExampleDto, UpdateExampleDto>
{
    public ExampleController(IExampleService service, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(service, mapper, httpContextAccessor)
    {

    }

}