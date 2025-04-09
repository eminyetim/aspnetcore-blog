using System.ComponentModel.DataAnnotations;

namespace BlogApp.DTOs.Blog
{
    public class CreateBlogDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public int UserId { get; set; } // Şimdilik sabit kullanıcı

        public DateTime PublishDate { get; set; } = DateTime.Now;
    }
}
