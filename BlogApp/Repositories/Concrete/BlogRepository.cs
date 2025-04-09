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
    }
}
