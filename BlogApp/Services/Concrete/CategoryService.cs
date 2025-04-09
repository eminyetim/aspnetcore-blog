using BlogApp.Entitiy;
using BlogApp.Repositories;
using BlogApp.Services.Abstract;

namespace BlogApp.Services.Concrete
{
    public class CategoryService : GenericService<Category> , ICategoryService
    {
        public CategoryService(IGenericRepository<Category> repository) : base(repository)
        {
        }
    }

}
