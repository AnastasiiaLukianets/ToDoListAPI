using ToDoListAPI.Models;

namespace ToDoListAPI.Services
{
    // ITaskToDoService interface contains what it can do, but not, how it does, what it can do
    // Implementation details are in the respective TaskToDoService class that implements ITaskToDoService
    public interface ITaskToDoRepository //<T> : IDisposable //IAsyncDisposable
    {
        Task<IEnumerable<TaskToDoDTO?>> GetTasksToDo(); // GET all tasks
        Task<TaskToDoDTO?> GetTaskToDo(int id); // GET{id}
        Task<TaskToDoDTO?> AddTaskToDo(TaskToDoDTO task); // POST
        Task<TaskToDoDTO?> UpdateTaskToDo(TaskToDoDTO task); // PUT
        Task<TaskToDoDTO?> DeleteTaskToDo(int id); // DELETE{id}
    }
}
