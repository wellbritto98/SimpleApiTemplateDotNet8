using System.ComponentModel.DataAnnotations;

namespace SimpleApiTemplateDotNet8.Data.Dtos;

public class UpdateMedicationDto : BaseDto
{
    

public string Nome { get; set; }


public string ViaAdministracao { get; set; }


public decimal DosegemMaxima { get; set; }


public int IntervaloHoras { get; set; }

public decimal DoseMinima { get; set; }


public decimal DoseMaxima { get; set; }

public int EmbalagemMl { get; set; }
}
