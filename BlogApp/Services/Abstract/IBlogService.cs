using BlogApp.Entitiy;

namespace BlogApp.Services.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        Task<Blog> GetByIdWithIncludesAsync(int id);
    }
    
}
