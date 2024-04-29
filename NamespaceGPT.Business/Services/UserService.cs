using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;
using NamespaceGPT.Data.Repositories.Interfaces;

namespace NamespaceGPT.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public int AddUser(User user)
        {
            return userRepository.AddUser(user);
        }

        public int UserExists(User user)
        {
            return userRepository.UserExists(user);
        }

        public bool DeleteUser(int id)
        {
            return userRepository.DeleteUser(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }

        public User? GetUser(int id)
        {
            return userRepository.GetUser(id);
        }

        public bool UpdateUser(int id, User user)
        {
            return userRepository.UpdateUser(id, user);
        }
    }
}
