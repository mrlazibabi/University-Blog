using University_Blog.Models;

namespace University_Blog.Services
{
    public interface IUserService
    {
        public Task<int> AddUser(UserDTO model);
        public Task<List<UserDTO>> GetAllUsers();
        public Task<UserDTO> GetUserById(int id);
        public Task UpdateUser(int id, UserDTO model);
        public Task DeleteUser(int id);
    }
}
