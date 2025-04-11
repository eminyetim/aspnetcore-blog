    using AutoMapper;
using BlogApp.DTOs.Blog;
using BlogApp.Entitiy;
using BlogApp.Services.Abstract;
using BlogApp.Services.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace BlogApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly IAccountService _userService;
        private readonly IMapper _mapper;

        public BlogController(IBlogService blogService, ICategoryService categoryService, IAccountService userService, IMapper mapper)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _userService = userService;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = _userService.GetUserId(User);
            if (userId == Guid.Empty) return Unauthorized();

            var blogs = await _blogService.GetBlogsByUserIdAsync(userId);
            return View(blogs);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var blog = await _blogService.GetByIdWithCategoryAndUserAsync(id);
            return blog == null ? NotFound() : View(blog);
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categoryService.GetCategorySelectListAsync();
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBlogDto dto)
        {

            var userId = _userService.GetUserId(User);
            if (userId == Guid.Empty) return Unauthorized();

            var blog = _mapper.Map<Blog>(dto);
            blog.UserId = userId;

            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _categoryService.GetCategorySelectListAsync();
                return View(dto);
            }

            await _blogService.AddAsync(blog);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog == null) return NotFound();

            var userId = _userService.GetUserId(User);
            if (blog.UserId != userId) return Forbid();

            var dto = _mapper.Map<UpdateBlogDto>(blog);
            ViewBag.Categories = await _categoryService.GetCategorySelectListAsync(blog.CategoryId);

            return View(dto);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateBlogDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _categoryService.GetCategorySelectListAsync(dto.CategoryId);
                return View(dto);
            }

            var blog = await _blogService.GetByIdAsync(dto.Id);
            if (blog == null) return NotFound();

            var userId = _userService.GetUserId(User);
            if (blog.UserId != userId) return Forbid();

            _mapper.Map(dto, blog);
            await _blogService.UpdateAsync(blog);

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog == null) return NotFound();

            var userId = _userService.GetUserId(User);
            if (blog.UserId != userId) return Forbid();

            return View(blog);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            var userId = _userService.GetUserId(User);
            if (blog == null || blog.UserId != userId) return Forbid();

            await _blogService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
