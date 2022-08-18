using AutoMapper;
using ToDoListAPI.Models;
using ToDoListAPI.Repository;
using ToDoListAPI.ResponseDto;

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
            var tasksSource = await _taskToDoRepository.GetAll(); 
            var tasks = _mapper.Map<IEnumerable<TaskToDo?>, IEnumerable<TaskToDoResponse>>(tasksSource);
            return tasks;
        }
        public async Task<TaskToDoResponse?> GetTaskToDo(int id)
        {
            var taskSource = await _taskToDoRepository.GetById(id); 
            var task = _mapper.Map<TaskToDoResponse>(taskSource);
            return task;
        }
        public async Task<TaskToDo?> AddTaskToDo(TaskToDo task)
        {
            return await _taskToDoRepository.Add(task);
        }
        public async Task<TaskToDo?> UpdateTaskToDo(TaskToDo task)
        {
            return await _taskToDoRepository.Update(task); 
        }
        public async Task<TaskToDo?> DeleteTaskToDo(int id)
        {
            return await _taskToDoRepository.DeleteById(id); 
        }

        public async Task AssignUserToTask(int taskId, int userId)
        {
            var task = await _taskToDoRepository.GetById(taskId);
            task.UserId = userId;
            await _taskToDoRepository.Update(task);
        }
        #endregion 
    }
}
