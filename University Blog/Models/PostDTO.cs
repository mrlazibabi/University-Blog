using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using University_Blog.Data;

namespace University_Blog.Models
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
