using System.ComponentModel.DataAnnotations;

namespace SimpleApiTemplateDotNet8.Data.Dtos.Auth;

public class JwtDto
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Id { get; set; }
    [Required]
    public string Role { get; set; }

}