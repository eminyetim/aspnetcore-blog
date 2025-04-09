using System.ComponentModel.DataAnnotations;

namespace BlogApp.Entitiy
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //  Bir kategoriye ait birden fazla blog yazısı olabilir
        public ICollection<Blog> Blogs { get; set; }
    }
}
