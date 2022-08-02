using ToDoListAPI.Models;

namespace ToDoListAPI.Services
{
    public interface ITaskToDoService
    {
        Task<IEnumerable<TaskToDoResponse>> GetTasksToDo(); // returns new model
        Task<TaskToDoResponse> GetTaskToDo(int id);
        Task<TaskToDoDTO> AddTaskToDo(TaskToDoDTO task);
        Task<TaskToDoDTO> UpdateTaskToDo(TaskToDoDTO task); 
        Task<TaskToDoDTO> DeleteTaskToDo(int id); 
    }
}
