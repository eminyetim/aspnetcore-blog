using BlogApp.Entitiy;
using BlogApp.Repositories;
using BlogApp.Repositories.Abstract;
using BlogApp.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Services.Concrete
{
    public class BlogService : GenericService<Blog>, IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository) : base(blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<Blog> GetByIdWithIncludesAsync(int id)
        {
            return await _blogRepository.GetByIdWithIncludesAsync(id);
        }

        public async Task<IEnumerable<Blog>> GetAllWithCategoryAndUserAsync()
        {
            return await _blogRepository.GetAllWithCategoryAndUserAsync();
        }

        public async Task<Blog> GetByIdWithCategoryAndUserAsync(int id)
        {
            return await _blogRepository.GetByIdWithCategoryAndUserAsync(id);
        }
        public async Task<IEnumerable<Blog>> GetBlogsByUserIdAsync(Guid userId)
        {
            return await _blogRepository.GetBlogsByUserIdAsync(userId);
        }

        public async Task<List<Blog>> GetBlogsByCategoryIdAsync(int categoryId)
        {
            return await _blogRepository.GetBlogsByCategoryIdAsync(categoryId);
        }

    }
}
