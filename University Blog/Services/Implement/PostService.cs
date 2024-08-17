using University_Blog.Models;
using University_Blog.Repositories.Implement;

namespace University_Blog.Services.Implement
{
    public class PostService : IPostService
    {
        private readonly PostRepository _postRepository;

        public PostService(PostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public Task<int> AddPost(PostDTO model)
        {
            return _postRepository.AddPost(model);
        }

        public Task DeletePost(int id)
        {
            return _postRepository.DeletePost(id);
        }

        public Task<List<PostDTO>> GetAllPosts()
        {
            return _postRepository.GetAllPosts();
        }

        public Task<PostDTO> GetPostById(int id)
        {
            return _postRepository.GetPostById(id);
        }

        public Task<IEnumerable<PostDTO>> GetPostsByTitle(string title)
        {
            return _postRepository.GetPostsByTitle(title);
        }

        public Task UpdatePost(int id, PostDTO model)
        {
            return _postRepository.UpdatePost(id, model);
        }
    }
}
