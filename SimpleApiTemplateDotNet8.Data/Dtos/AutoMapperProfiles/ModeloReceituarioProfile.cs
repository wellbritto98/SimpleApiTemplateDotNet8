using AutoMapper;
using SimpleApiTemplateDotNet8.Models;

namespace SimpleApiTemplateDotNet8.Data.Dtos.AutoMapperProfiles;

public class ModeloReceituarioProfile : Profile
{
    public ModeloReceituarioProfile()
    {
        CreateMap<ModeloReceituario, InsertModeloReceituarioDto>().ReverseMap();
        CreateMap<ModeloReceituario, ReadModeloReceituarioDto>().ReverseMap();
        CreateMap<ModeloReceituario, UpdateModeloReceituarioDto>().ReverseMap();
    }

}
