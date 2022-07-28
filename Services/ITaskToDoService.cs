namespace ToDoListAPI.Services
{
    // ITaskToDoService interface contains what it can do, but not, how it does, what it can do
    // Implementation details are in the respective TaskToDoService class that implements ITaskToDoService
    public interface ITaskToDoService //<T> : IDisposable //IAsyncDisposable
    {
        Task<IEnumerable<TaskToDo>> GetTasksToDo(); // GET all tasks
        Task<TaskToDo> GetTaskToDo(int id); // GET{id}
        Task<TaskToDo> AddTaskToDo(TaskToDo task); // POST
        Task<TaskToDo> UpdateTaskToDo(TaskToDo task); // PUT
        Task<TaskToDo> DeleteTaskToDo(int id); // DELETE{id}
    }
}
