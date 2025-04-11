using BlogApp.Entitiy;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogApp.Services.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        Task<SelectList> GetCategorySelectListAsync(int? selectedId = null);

    }
}
