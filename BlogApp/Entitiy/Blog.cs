using System.ComponentModel.DataAnnotations;

namespace BlogApp.Entitiy
{
    public class Blog
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PublishDate { get; set; } = DateTime.Now;

        public string? ImagePath { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
}
