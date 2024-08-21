using SimpleApiTemplateDotNet8.Data.Dtos.Auth;
using SimpleApiTemplateDotNet8.Models.ApiResponse;
using System.Threading.Tasks;

namespace SimpleApiTemplateDotNet8.Services.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse> RegisterUser(RegisterUserDto dto);
        Task<ApiResponse> LoginUser(LoginUserDto dto);
        Task<ApiResponse> RefreshToken();
    }
}
