using BlogApp.DTOs.User;
using System.Security.Claims;

namespace BlogApp.Services.Abstract
{
    public interface IAccountService
    {
        Task<(bool Succeeded, IEnumerable<string> Errors)> RegisterAsync(RegisterViewModel model);
        Task<bool> LoginAsync(LoginModel model);
        Task LogoutAsync();
        Guid GetUserId(ClaimsPrincipal user);
    }
}
