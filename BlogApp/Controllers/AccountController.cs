using BlogApp.DTOs.User;
using BlogApp.Entitiy;
using BlogApp.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;


        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var (succeeded, errors) = await _accountService.RegisterAsync(model);

            if (succeeded)
                return RedirectToAction("Login", "Account");

            foreach (var error in errors)
                ModelState.AddModelError("", error);

            return View(model);
        }

        [HttpGet]
        public IActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _accountService.LoginAsync(model);

            if (result)
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre.");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
