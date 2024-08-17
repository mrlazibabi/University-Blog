using University_Blog.Models;
using University_Blog.Repositories.Implement;

namespace University_Blog.Services.Implement
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<int> AddUser(UserDTO model)
        {
            return _userRepository.AddUser(model);
        }

        public Task DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }

        public Task<List<UserDTO>> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public Task<UserDTO> GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public Task UpdateUser(int id, UserDTO model)
        {
            return _userRepository.UpdateUser(id, model);
        }
    }
}
