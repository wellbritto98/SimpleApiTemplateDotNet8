using AutoMapper;
using SimpleApiTemplate.Web.Dtos;

namespace SimpleApiTemplate.Web.Dtos.AutoMapperProfiles;

public class BaseProfile : Profile
{

    public BaseProfile()
    {
        CreateMap<SimpleApiTemplateDotNet8.Models.Base.BaseEntity, BaseDto>().ReverseMap();
    }

}