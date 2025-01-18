using AutoMapper;
using SimpleApiTemplateDotNet8.Models;

namespace SimpleApiTemplateDotNet8.Data.Dtos.AutoMapperProfiles;

public class MedicationProfile : Profile
{
    public MedicationProfile()
    {
        CreateMap<Medication, InsertMedicationDto>().ReverseMap();
        CreateMap<Medication, ReadMedicationDto>().ReverseMap();
        CreateMap<Medication, UpdateMedicationDto>().ReverseMap();
    }

}
