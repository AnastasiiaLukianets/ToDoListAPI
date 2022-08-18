using ToDoListAPI.Models;
using ToDoListAPI.ResponseDto;

namespace ToDoListAPI.Services
{
    public interface ITaskToDoService
    {
        Task<IEnumerable<TaskToDoResponse?>> GetTasksToDo();
        Task<TaskToDoResponse?> GetTaskToDo(int id);
        Task<TaskToDo?> AddTaskToDo(TaskToDo task);
        Task<TaskToDo?> UpdateTaskToDo(TaskToDo task); 
        Task<TaskToDo?> DeleteTaskToDo(int id);
        Task AssignUserToTask(int taskId, int userId);
    }
}
