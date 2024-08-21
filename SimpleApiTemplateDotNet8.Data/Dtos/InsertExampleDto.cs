using System.ComponentModel.DataAnnotations;

namespace SimpleApiTemplateDotNet8.Data.Dtos;

public class InsertExampleDto : BaseDto
{

    [Required]
    public string Name { get; set; }
    [Required]
    public string Nickname { get; set; }

}