using System.ComponentModel.DataAnnotations;

namespace SimpleApiTemplate.Models;

public abstract class BaseEntity
{
    [Key]
    [Required]
    public int Id { get; set; }
}
