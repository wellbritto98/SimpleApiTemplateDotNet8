using System.ComponentModel.DataAnnotations;

namespace SimpleApiTemplate.Models;

public abstract class BaseEntity
{
    [Required]
    public int Id { get; set; }
}
