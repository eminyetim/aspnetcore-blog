using BlogApp.Entitiy;

namespace BlogApp.Repositories.Abstract
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
        Task<Blog> GetByIdWithIncludesAsync(int id);
        Task<IEnumerable<Blog>> GetAllWithCategoryAndUserAsync();
        Task<Blog> GetByIdWithCategoryAndUserAsync(int id);
        Task<IEnumerable<Blog>> GetBlogsByUserIdAsync(Guid userId);
        Task<List<Blog>> GetBlogsByCategoryIdAsync(int categoryId);

    }
}
