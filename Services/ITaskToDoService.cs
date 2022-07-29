namespace ToDoListAPI.Services
{
    public interface ITaskToDoService
    {
        // ITaskToDoRepository may be inherited from IGenericTaskToDoRepository<TaskToDo>
        ITaskToDoRepository TaskToDoRepository { get; }
    }
}
