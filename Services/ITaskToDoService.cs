using ToDoListAPI.Models;

namespace ToDoListAPI.Services
{
    public interface ITaskToDoService
    {
        Task<IEnumerable<TaskToDoResponse?>> GetTasksToDo(); // returns new model
        Task<TaskToDoResponse?> GetTaskToDo(int id);
        Task<TaskToDo?> AddTaskToDo(TaskToDo task);
        Task<TaskToDo?> UpdateTaskToDo(TaskToDo task); 
        Task<TaskToDo?> DeleteTaskToDo(int id);
        Task AssignUserToTask(int taskId, int userId);
    }
}
