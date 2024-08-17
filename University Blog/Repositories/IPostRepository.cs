using University_Blog.Models;

namespace University_Blog.Repositories
{
    public interface IPostRepository
    {
        public Task<int> AddPost(PostDTO model);
        public Task<List<PostDTO>> GetAllPosts();
        public Task<PostDTO> GetPostById(int id);
        public Task UpdatePost(int id, PostDTO model);
        public Task DeletePost(int id);
        public Task<IEnumerable<PostDTO>> GetPostsByTitle(string title);
    }
}
