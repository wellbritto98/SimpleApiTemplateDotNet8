using SimpleApiTemplateDotNet8.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleApiTemplateDotNet8.Models;

public class Medication : BaseEntity 
{
[Key]
[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
public int Id { get; set; }

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
