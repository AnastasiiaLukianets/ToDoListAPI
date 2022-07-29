using Microsoft.EntityFrameworkCore;

namespace ToDoListAPI.Services
{
    // Move logic related to DataContext here
    // Create 1 method for each controller method
    public class TaskToDoService : ITaskToDoService
    {
        private readonly DataContext _dataContext;
        public TaskToDoService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<TaskToDo> AddTaskToDo(TaskToDo task)
        {
            var result = await _dataContext.TasksToDo.AddAsync(task);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TaskToDo?> DeleteTaskToDo(int id)
        {
            var result = await _dataContext.TasksToDo
                .FirstOrDefaultAsync(t => t.Id == id);

            if (result != null)
            {
                _dataContext.TasksToDo.Remove(result);
                await _dataContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<IEnumerable<TaskToDo>> GetTasksToDo()
        {
            return await _dataContext.TasksToDo.ToListAsync();
        }

        public async Task<TaskToDo?> GetTaskToDo(int id)
        {
            return await _dataContext.TasksToDo
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TaskToDo?> UpdateTaskToDo(TaskToDo task)
        {
            var result = await _dataContext.TasksToDo
                .FirstOrDefaultAsync(t => t.Id == task.Id);

            if (result != null)
            {
                result.DescriptionText = task.DescriptionText;
                result.IsCompleted = task.IsCompleted;
                result.DueDate = task.DueDate;

                await _dataContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
