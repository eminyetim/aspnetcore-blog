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
    }
}
