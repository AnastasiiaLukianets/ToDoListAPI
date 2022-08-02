using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Models;

namespace ToDoListAPI.Services
{
    // Move logic related to DataContext here
    // Create 1 method for each controller method
    public class TaskToDoRepository : ITaskToDoRepository
    {
        private readonly DataContext _dataContext;
        public TaskToDoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<TaskToDoDTO>> GetTasksToDo()
        {
            return await _dataContext.TasksToDo.ToListAsync();
        }

        public async Task<TaskToDoDTO?> GetTaskToDo(int id)
        {
            return await _dataContext.TasksToDo
                .FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<TaskToDoDTO> AddTaskToDo(TaskToDoDTO task)
        {
            var result = await _dataContext.TasksToDo.AddAsync(task);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TaskToDoDTO?> UpdateTaskToDo(TaskToDoDTO task)
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
        public async Task<TaskToDoDTO?> DeleteTaskToDo(int id)
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
    }
}
