using AutoMapper;
using SimpleApiTemplate.Data.Dtos;
using SimpleApiTemplate.Models;

namespace SimpleApiTemplate.Data.AutoMapperProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterUserDto, User>();
        CreateMap<LoginUserDto, User>();

    }
    
}