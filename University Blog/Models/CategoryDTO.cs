using System.ComponentModel.DataAnnotations;
using University_Blog.Data;

namespace University_Blog.Models
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
