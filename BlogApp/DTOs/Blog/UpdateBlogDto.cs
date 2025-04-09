using System.ComponentModel.DataAnnotations;

namespace BlogApp.DTOs.Blog
{
    public class UpdateBlogDto
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public int UserId { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
