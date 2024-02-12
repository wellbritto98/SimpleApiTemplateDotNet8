using Microsoft.AspNetCore.Identity;

namespace SimpleApiTemplate.Models;

public class User : IdentityUser
{
    
    public string Nickname { get; set; } 
    public DateTime RegisteredAt { get; set; }
    public DateTime DataNascimento { get; set; }
    public DateTime? LastLoginAt { get; set; }
}