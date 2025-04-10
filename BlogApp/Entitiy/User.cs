using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Entitiy
{
    public class User : IdentityUser<Guid>
    {
        //Bir kullanıcının birden çok blog yazısı olabilir
        public ICollection<Blog> Blogs { get; set; }
    }
}
