using AutoMapper;

namespace SimpleApiTemplate.Data.AutoMapperProfiles;

public class BaseProfile : Profile
{

    public BaseProfile()
    {
        CreateMap<Models.BaseEntity, Data.Dtos.BaseDto>().ReverseMap();
    }
    
}