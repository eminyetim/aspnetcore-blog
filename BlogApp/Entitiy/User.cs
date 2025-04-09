using System.ComponentModel.DataAnnotations;

namespace BlogApp.Entitiy
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        //Bir kullanıcının birden çok blog yazısı olabilir
        public ICollection<Blog> Blogs { get; set; }
    }
}
