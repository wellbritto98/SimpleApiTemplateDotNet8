using System.ComponentModel.DataAnnotations;

namespace SimpleApiTemplateDotNet8.Data.Dtos;

public class InsertMedicationDto : BaseDto
{
    
[Required]
public string Nome { get; set; }

[Required]
public string ViaAdministracao { get; set; }

[Required]
public decimal DosegemMaxima { get; set; }

[Required]
public int IntervaloHoras { get; set; }

[Required]
public decimal DoseMinima { get; set; }

[Required]
public decimal DoseMaxima { get; set; }

[Required]
public int EmbalagemMl { get; set; }
}
