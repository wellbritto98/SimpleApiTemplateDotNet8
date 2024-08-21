using SimpleApiTemplateDotNet8.Data.Dtos.Auth;

namespace SimpleApiTemplateDotNet8.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(JwtDto dto);
        bool VerifyJwt(string token);
    }
}
