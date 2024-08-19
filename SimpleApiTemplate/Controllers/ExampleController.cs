using AutoMapper;
using SimpleApiTemplateDotNet8.Models;
using SimpleApiTemplateDotNet8.Repository.Interfaces;
using SimpleApiTemplate.Web.Controllers.GenericController;
using SimpleApiTemplate.Web.Dtos;

namespace SimpleApiTemplate.Web.Controllers;

public class ExampleController : GenericController<ExampleEntity, InsertExampleDto, ReadExampleDto, UpdateExampleDto>
{
    public ExampleController(IExampleRepository repository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(repository, mapper, httpContextAccessor)
    {

    }

}