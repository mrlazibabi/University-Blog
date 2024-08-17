using AutoMapper;
using Microsoft.EntityFrameworkCore;
using University_Blog.Data;
using University_Blog.Models;

namespace University_Blog.Repositories.Implement
{
    public class UserRepository : IUserRepository
    {
        private readonly UniversityBlogContext _DbContext;
        private readonly IMapper _mapper;

        public UserRepository(UniversityBlogContext dbContext, IMapper mapper)
        {
            _DbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<int> AddUser(UserDTO model)
        {
            var newUser = _mapper.Map<User>(model);
            _DbContext.Users.Add(newUser);
            await _DbContext.SaveChangesAsync();

            return newUser.UserId;
        }

        public async Task DeleteUser(int id)
        {
            var deleteUser = _DbContext.Users.SingleOrDefault(x => x.UserId == id);
            if (deleteUser != null)
            {
                _DbContext.Users.Remove(deleteUser);
                await _DbContext.SaveChangesAsync();
            }
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            var listUser = _DbContext.Users.ToListAsync();

            return _mapper.Map<List<UserDTO>>(listUser);
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            var user = await _DbContext.Users!.FindAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task UpdateUser(int id, UserDTO model)
        {
            if (id == model.UserId)
            {
                var updateUser = _mapper.Map<User>(model);
                _DbContext.Users!.Update(updateUser);
                await _DbContext.SaveChangesAsync();
            }
        }
    }
}
