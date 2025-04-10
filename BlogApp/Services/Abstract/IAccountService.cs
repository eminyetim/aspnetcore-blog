using BlogApp.DTOs.User;

namespace BlogApp.Services.Abstract
{
    public interface IAccountService
    {
        Task<(bool Succeeded, IEnumerable<string> Errors)> RegisterAsync(RegisterViewModel model);
        Task<bool> LoginAsync(LoginModel model);
        Task LogoutAsync();
    }
}
