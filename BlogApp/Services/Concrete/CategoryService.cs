using BlogApp.Entitiy;
using BlogApp.Repositories;
using BlogApp.Services.Abstract;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogApp.Services.Concrete
{
    public class CategoryService : GenericService<Category> , ICategoryService
    {
        public CategoryService(IGenericRepository<Category> repository) : base(repository)
        {
        }

        public async Task<SelectList> GetCategorySelectListAsync(int? selectedId = null)
        {
            var categories = await GetAllAsync(); // mevcut metodun
            return new SelectList(categories, "Id", "Name", selectedId);
        }

    }

}
