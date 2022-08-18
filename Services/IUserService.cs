using ToDoListAPI.Models;
using ToDoListAPI.ResponseDto;

namespace ToDoListAPI.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponse?>> GetUsers(); 
        Task<UserResponse?> GetUser(int id);
        Task<User?> AddUser(User user);
        Task<User?> UpdateUser(User user);
        Task<User?> DeleteUser(int id);

    }
}
