using AutoMapper;
using SimpleApiTemplate.Data.Dtos;
using SimpleApiTemplate.Models;
using SimpleApiTemplate.Controllers.GenericController;
using SimpleApiTemplate.Services.Interfaces;

namespace SimpleApiTemplate.Controllers;

public class ExampleController : GenericController<ExampleEntity, InsertExampleDto, ReadExampleDto, UpdateExampleDto>
{
    public ExampleController( IExampleRepository repository, IMapper mapper,  IHttpContextAccessor httpContextAccessor) : base( repository, mapper, httpContextAccessor)
    {
        
    }
    
}