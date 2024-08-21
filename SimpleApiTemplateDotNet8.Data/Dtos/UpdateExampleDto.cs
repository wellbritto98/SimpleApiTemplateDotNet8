using System.ComponentModel.DataAnnotations;

namespace SimpleApiTemplateDotNet8.Data.Dtos;

public class UpdateExampleDto : BaseDto
{

    [Required]
    public string Name { get; set; }
    [Required]
    public string Nickname { get; set; }

}