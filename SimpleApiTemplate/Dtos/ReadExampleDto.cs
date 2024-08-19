using System.ComponentModel.DataAnnotations;

namespace SimpleApiTemplate.Web.Dtos;

public class ReadExampleDto : BaseDto
{

    [Required]
    public string Name { get; set; }
    [Required]
    public string Nickname { get; set; }

}