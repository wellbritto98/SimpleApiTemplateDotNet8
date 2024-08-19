namespace SimpleApiTemplateDotNet8.Models.Auth;

public class RefreshToken
{
    public required string Token { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime Expired { get; set; } = DateTime.Now.AddMonths(6);
}