using System.ComponentModel.DataAnnotations;

namespace SimpleApiTemplate.Data.Dtos;

public class JwtDto
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Id { get; set; }
    
}