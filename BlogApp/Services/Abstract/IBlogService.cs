using BlogApp.Entitiy;

namespace BlogApp.Services.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        Task<Blog> GetByIdWithIncludesAsync(int id);
        Task<IEnumerable<Blog>> GetAllWithCategoryAndUserAsync();
        Task<Blog> GetByIdWithCategoryAndUserAsync(int id);
        Task<IEnumerable<Blog>> GetBlogsByUserIdAsync(Guid userId);
        Task<List<Blog>> GetBlogsByCategoryIdAsync(int categoryId);


    }

}
