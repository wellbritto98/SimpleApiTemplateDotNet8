using System.ComponentModel.DataAnnotations;

namespace SimpleApiTemplate.Models;

public class ExampleEntity : BaseEntity
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Nickname { get; set; }
    public bool IsConfirmed { get; set; }

}