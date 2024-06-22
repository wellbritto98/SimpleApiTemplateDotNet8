using AutoMapper;
using SimpleApiTemplate.Data.Dtos;
using SimpleApiTemplate.Models;

namespace SimpleApiTemplate.Data.AutoMapperProfiles;

public class ExampleProfile : Profile
{
    public ExampleProfile()
    {
        CreateMap<ExampleEntity, InsertExampleDto>().ReverseMap();
        CreateMap<ExampleEntity, ReadExampleDto>().ReverseMap();
        CreateMap<ExampleEntity, UpdateExampleDto>().ReverseMap();
    }
    
}