using AutoMapper;
using ToDoListAPI.Models;

namespace ToDoListAPI.Services
{
    public class TaskToDoService : ITaskToDoService
    {
        private readonly ITaskToDoRepository _taskToDoRepository;
        private readonly IMapper _mapper;

        public TaskToDoService(ITaskToDoRepository taskToDoRepository, IMapper mapper)
        {
            _taskToDoRepository = taskToDoRepository;
            _mapper = mapper;
        }

        #region "ITaskToDoService implementation
        public async Task<IEnumerable<TaskToDoResponse>> GetTasksToDo()
        {
            var tasksSource = await _taskToDoRepository.GetTasksToDo();
            var tasks = _mapper.Map<List<TaskToDoResponse>>(tasksSource);
            return tasks;
        }
        public async Task<TaskToDoResponse> GetTaskToDo(int id)
        {
            var taskSource = await _taskToDoRepository.GetTaskToDo(id);
            var task = _mapper.Map<TaskToDoResponse>(taskSource);
            return task;
        }
        public async Task<TaskToDoDTO> AddTaskToDo(TaskToDoDTO task)
        {
            return await _taskToDoRepository.AddTaskToDo(task);
        }
        public async Task<TaskToDoDTO> UpdateTaskToDo(TaskToDoDTO task)
        {
            return await _taskToDoRepository.UpdateTaskToDo(task);
        }
        public async Task<TaskToDoDTO> DeleteTaskToDo(int id)
        {
            return await _taskToDoRepository.DeleteTaskToDo(id);
        }
        #endregion 
    }
}
