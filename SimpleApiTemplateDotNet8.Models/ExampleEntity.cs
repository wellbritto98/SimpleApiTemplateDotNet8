using SimpleApiTemplateDotNet8.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleApiTemplateDotNet8.Models;

public class ExampleEntity : BaseEntity
{
    [Key, Column(Order = 0)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Nickname { get; set; }
    public bool IsConfirmed { get; set; }

}