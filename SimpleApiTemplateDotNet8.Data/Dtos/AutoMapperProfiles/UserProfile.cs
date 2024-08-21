using AutoMapper;
using SimpleApiTemplateDotNet8.Data.Dtos.Auth;
using SimpleApiTemplateDotNet8.Models.Auth;

namespace SimpleApiTemplateDotNet8.Data.Dtos.AutoMapperProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterUserDto, User>();
        CreateMap<LoginUserDto, User>();

    }

}