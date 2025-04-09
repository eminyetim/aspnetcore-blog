using BlogApp.Entitiy;

namespace BlogApp.Repositories.Abstract
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
        Task<Blog> GetByIdWithIncludesAsync(int id);
    }
}
