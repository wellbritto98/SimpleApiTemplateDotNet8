using AutoMapper;
using SimpleApiTemplate.Web.Dtos;
using SimpleApiTemplateDotNet8.Models;

namespace SimpleApiTemplate.Web.Dtos.AutoMapperProfiles;

public class ExampleProfile : Profile
{
    public ExampleProfile()
    {
        CreateMap<ExampleEntity, InsertExampleDto>().ReverseMap();
        CreateMap<ExampleEntity, ReadExampleDto>().ReverseMap();
        CreateMap<ExampleEntity, UpdateExampleDto>().ReverseMap();
    }

}