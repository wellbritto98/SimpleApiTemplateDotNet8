using AutoMapper;
using SimpleApiTemplate.Web.Dtos.Auth;
using SimpleApiTemplateDotNet8.Models.Auth;

namespace SimpleApiTemplate.Web.Dtos.AutoMapperProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterUserDto, User>();
        CreateMap<LoginUserDto, User>();

    }

}