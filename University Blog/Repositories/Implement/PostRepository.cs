using AutoMapper;
using Microsoft.EntityFrameworkCore;
using University_Blog.Data;
using University_Blog.Models;


namespace University_Blog.Repositories.Implement
{
    public class PostRepository : IPostRepository
    {
        private readonly UniversityBlogContext _DbContext;
        private readonly IMapper _mapper;

        public PostRepository(UniversityBlogContext dbContext, IMapper mapper)
        {
            _DbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int> AddPost(PostDTO model)
        {
            var newPost = _mapper.Map<Post>(model);
            _DbContext.Posts!.Add(newPost);
            await _DbContext.SaveChangesAsync();

            return newPost.Id;
        }

        public async Task DeletePost(int id)
        {
            var deletePost = _DbContext.Posts!.SingleOrDefault(x => x.Id == id);
            if (deletePost != null)
            {
                _DbContext.Posts!.Remove(deletePost);
                await _DbContext.SaveChangesAsync();
            }
        }

        public async Task<List<PostDTO>> GetAllPosts()
        {
            var listPost = await _DbContext.Posts.ToListAsync();
            
            return _mapper.Map<List<PostDTO>>(listPost);
        }

        public async Task<PostDTO> GetPostById(int id)
        {
            var post = await _DbContext.Posts!.FindAsync(id);
            return _mapper.Map<PostDTO>(post);
        }

        public async Task<IEnumerable<PostDTO>> GetPostsByTitle(string title)
        {
            var posts = await _DbContext.Posts!
                .Where(p => p.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();

            return _mapper.Map<IEnumerable<PostDTO>>(posts);
        }

        public async Task UpdatePost(int id, PostDTO model)
        {
            if (id == model.Id)
            {
                var updatePost = _mapper.Map<Post>(model);
                _DbContext.Posts!.Update(updatePost);
                await _DbContext.SaveChangesAsync();
            }
        }
    }
}
