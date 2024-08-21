using AutoMapper;
using SimpleApiTemplateDotNet8.Data.Dtos;

namespace SimpleApiTemplateDotNet8.Data.Dtos.AutoMapperProfiles;

public class BaseProfile : Profile
{

    public BaseProfile()
    {
        CreateMap<Models.Base.BaseEntity, BaseDto>().ReverseMap();
    }

}