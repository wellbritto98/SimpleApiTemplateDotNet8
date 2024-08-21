using AutoMapper;
using SimpleApiTemplateDotNet8.Models;

namespace SimpleApiTemplateDotNet8.Data.Dtos.AutoMapperProfiles;

public class ExampleProfile : Profile
{
    public ExampleProfile()
    {
        CreateMap<ExampleEntity, InsertExampleDto>().ReverseMap();
        CreateMap<ExampleEntity, ReadExampleDto>().ReverseMap();
        CreateMap<ExampleEntity, UpdateExampleDto>().ReverseMap();
    }

}