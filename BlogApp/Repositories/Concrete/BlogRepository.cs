using BlogApp.Data;
using BlogApp.Entitiy;
using BlogApp.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Repositories.Concrete
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        private readonly AppDbContext _context;

        public BlogRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Blog> GetByIdWithIncludesAsync(int id)
        {
            return await _context.Blogs
                .Include(b => b.Category)
                .Include(b => b.User)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Blog>> GetAllWithCategoryAndUserAsync()
        {
            return await _context.Blogs
                .Include(b => b.Category)
                .Include(b => b.User)
                .OrderByDescending(b => b.PublishDate)
                .ToListAsync();
        }

        public async Task<Blog> GetByIdWithCategoryAndUserAsync(int id)
        {
            return await _context.Blogs
                .Include(b => b.Category)
                .Include(b => b.User)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Blog>> GetBlogsByUserIdAsync(Guid userId)
        {
            return await _context.Blogs
                 .Include(b => b.Category)
                 .Where(b => b.UserId == userId)
                 .ToListAsync();

        }

        public async Task<List<Blog>> GetBlogsByCategoryIdAsync(int categoryId)
        {
            return await _context.Blogs
                .Where(b => b.CategoryId == categoryId)
                .Include(b => b.User)
                .ToListAsync();
        }

    }
}
