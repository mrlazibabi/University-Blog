using Microsoft.EntityFrameworkCore;

namespace University_Blog.Data
{
    public class UniversityBlogContext: DbContext
    {
        public UniversityBlogContext(DbContextOptions<UniversityBlogContext>opt): base(opt)
        {

        }

        #region DbSet
        public DbSet<Post>? Posts { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion
    }
}
