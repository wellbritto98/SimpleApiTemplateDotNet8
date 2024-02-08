using AutoMapper;
using SimpleApiTemplate.Data.Dtos;
using SimpleApiTemplate.Models;
using SimpleApiTemplate.Controllers.GenericController;
using SimpleApiTemplate.Services.Interfaces;

namespace SimpleApiTemplate.Controllers;

public class ExampleController : GenericController<ExampleEntity>
{
    public ExampleController( IExampleRepository repository, IHttpContextAccessor httpContextAccessor) : base( repository, httpContextAccessor)
    {
        
    }
    
}