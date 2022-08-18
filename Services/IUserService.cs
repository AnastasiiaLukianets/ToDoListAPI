using ToDoListAPI.Models;

namespace ToDoListAPI.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponse?>> GetUsers(); 
        Task<UserResponse?> GetUser(int id);
        Task<User?> AddUser(User user);
        Task<User?> UpdateUser(User user);
        Task<User?> DeleteUser(int id);
        Task<User?> AddTaskForUser(int userId, int taskId);
    }
}
