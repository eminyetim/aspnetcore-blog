namespace BlogApp.DTOs.Blog
{
    public class BlogDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public string CategoryName { get; set; }
        public string? AuthorName { get; set; }
    }
}
