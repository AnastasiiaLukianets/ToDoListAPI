using AutoMapper;
using ToDoListAPI.Models;
using ToDoListAPI.Repository;

namespace ToDoListAPI.Services
{
    public class TaskToDoService : ITaskToDoService
    {
        private readonly IRepository<TaskToDo> _taskToDoRepository;
        private readonly IMapper _mapper;

        public TaskToDoService(IRepository<TaskToDo> taskToDoRepository, IMapper mapper)
        {
            _taskToDoRepository = taskToDoRepository;
            _mapper = mapper;
        }

        #region ITaskToDoService_implementation
        public async Task<IEnumerable<TaskToDoResponse?>> GetTasksToDo()
        {
            var tasksSource = await _taskToDoRepository.GetAll(); //GetTasksToDo();
            var tasks = _mapper.Map<IEnumerable<TaskToDo?>, IEnumerable<TaskToDoResponse>>(tasksSource);
            return tasks;
        }
        public async Task<TaskToDoResponse?> GetTaskToDo(int id)
        {
            var taskSource = await _taskToDoRepository.GetById(id); //GetTaskToDo(id);
            var task = _mapper.Map<TaskToDoResponse>(taskSource);
            return task;
        }
        public async Task<TaskToDo?> AddTaskToDo(TaskToDo task)
        {
            return await _taskToDoRepository.Add(task); //AddTaskToDo(task);
        }
        public async Task<TaskToDo?> UpdateTaskToDo(TaskToDo task)
        {
            return await _taskToDoRepository.Update(task); //UpdateTaskToDo(task);
        }
        public async Task<TaskToDo?> DeleteTaskToDo(int id)
        {
            return await _taskToDoRepository.DeleteById(id); //DeleteTaskToDo(id);
        }
        #endregion 
    }
}
