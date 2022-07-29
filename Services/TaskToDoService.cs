namespace ToDoListAPI.Services
{
    public class TaskToDoService : ITaskToDoService
    {
        //private readonly ITaskToDoRepository _taskToDoRepository;
        public TaskToDoService(ITaskToDoRepository taskToDoRepository)
        {
            TaskToDoRepository = taskToDoRepository;
        }

        public ITaskToDoRepository TaskToDoRepository { get; }
    }
}
