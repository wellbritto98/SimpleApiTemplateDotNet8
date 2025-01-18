using AutoMapper;
using SimpleApiTemplateDotNet8.Models;
using SimpleApiTemplateDotNet8.Repository.Interfaces;
using SimpleApiTemplateDotNet8.Web.Controllers.GenericController;
using SimpleApiTemplateDotNet8.Data.Dtos;
using SimpleApiTemplateDotNet8.Services.Interfaces;

namespace SimpleApiTemplateDotNet8.Web.Controllers;
public class MedicationQueryParams
{
    public int Id { get; set; }
}
public class MedicationController : GenericController<Medication, InsertMedicationDto, ReadMedicationDto, UpdateMedicationDto, MedicationQueryParams>
{
    public MedicationController(IMedicationService service, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(service, mapper, httpContextAccessor)
    {

    }

}
