using SimpleApiTemplateDotNet8.Models;
using SimpleApiTemplateDotNet8.Repository.Interfaces;
using SimpleApiTemplateDotNet8.Services.GenericService;
using SimpleApiTemplateDotNet8.Services.Interfaces;

namespace SimpleApiTemplateDotNet8.Services
{
    public class MedicationService : GenericService<Medication>, IMedicationService
    {
        private readonly IMedicationRepository _Repository;

        public MedicationService(IMedicationRepository Repository) : base(Repository)
        {
            _Repository = Repository;
        }
    }
}
