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
        private readonly IMapper _mapper;

        public BlogController(IBlogService blogService, ICategoryService categoryService, IMapper mapper)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // GET: Blog
        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetAllAsync();
            return View(blogs);
        }

        // GET: Blog/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var blog = await _blogService.GetByIdWithIncludesAsync(id);
            if (blog == null)
                return NotFound();

            var dto = _mapper.Map<BlogDetailDto>(blog);
            return View(dto);
        }

        [Authorize]
        // GET: Blog/Create
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userIdString, out Guid userId))
            {
                // Eğer ID alınamazsa, hata döndür
                return Unauthorized();
            }
            ViewBag.UserId = userIdString;
            return View();
        }


        // POST: Blog/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBlogDto dto)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryService.GetAllAsync();
                ViewBag.Categories = new SelectList(categories, "Id", "Name");
                return View(dto);
            }

            var blog = _mapper.Map<Blog>(dto);

            await _blogService.AddAsync(blog);
            return RedirectToAction(nameof(Index));
        }


        // GET: Blog/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog == null) return NotFound();

            var dto = _mapper.Map<UpdateBlogDto>(blog);

            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", blog.CategoryId);

            return View(dto);
        }


        // POST: Blog/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateBlogDto dto)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryService.GetAllAsync();
                ViewBag.Categories = new SelectList(categories, "Id", "Name", dto.CategoryId);
                return View(dto);
            }

            var updatedBlog = _mapper.Map<Blog>(dto);
            await _blogService.UpdateAsync(updatedBlog);
            return RedirectToAction(nameof(Index));
        }


        // GET: Blog/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog == null)
                return NotFound();
            return View(blog);
        }

        // POST: Blog/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _blogService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
