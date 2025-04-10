using BlogApp.Models;
using BlogApp.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IBlogService _blogService;

        public HomeController(ILogger<HomeController> logger, IBlogService blogService, ICategoryService categoryService)
        {
            _logger = logger;
            _blogService = blogService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int? categoryId)
        {
            var blogs = categoryId.HasValue
                ? await _blogService.GetBlogsByCategoryIdAsync(categoryId.Value)
                : await _blogService.GetAllWithCategoryAndUserAsync();

            var categories = await _categoryService.GetAllAsync();

            ViewBag.Categories = categories;
            ViewBag.SelectedCategoryId = categoryId;

            return View(blogs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
