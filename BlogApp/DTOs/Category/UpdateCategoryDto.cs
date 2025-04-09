using System.ComponentModel.DataAnnotations;

namespace BlogApp.DTOs.Category
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kategori adı boş bırakılamaz.")]
        public string Name { get; set; }
    }
}
