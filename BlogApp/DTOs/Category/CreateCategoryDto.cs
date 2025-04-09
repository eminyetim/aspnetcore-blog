using System.ComponentModel.DataAnnotations;

namespace BlogApp.DTOs.Category
{
    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "Kategori adı boş bırakılamaz.")]
        public string Name { get; set; }
    }
}
