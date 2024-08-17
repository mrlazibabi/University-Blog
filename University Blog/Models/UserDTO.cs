using System.ComponentModel.DataAnnotations;

namespace University_Blog.Models
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
