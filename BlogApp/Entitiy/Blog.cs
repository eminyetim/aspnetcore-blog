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


        // Foreign Key - User
        public int UserId { get; set; }
        public User User { get; set; }


        // Foreign Key - Category
        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
}
