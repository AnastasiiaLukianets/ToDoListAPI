using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Models;

namespace ToDoListAPI.Repository
{
    public class TaskToDoRepository : IRepository<TaskToDo>
    {
        private readonly DataContext _dataContext;
        public TaskToDoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<TaskToDo?>> GetAll() //GetTasksToDo
        {
            return await _dataContext.TasksToDo.ToListAsync();
        }

        public async Task<TaskToDo?> GetById(int id) //GetTaskToDo
        {
            return await _dataContext.TasksToDo
                .FirstOrDefaultAsync(t => t.TaskToDoId == id);
        }

        public async Task<TaskToDo?> Add(TaskToDo task) //AddTaskToDo
        {
            var result = await _dataContext.TasksToDo.AddAsync(task);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TaskToDo?> Update(TaskToDo task) //UpdateTaskToDo
        {
            var result = await _dataContext.TasksToDo
                .FirstOrDefaultAsync(t => t.TaskToDoId == task.TaskToDoId);

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
        public async Task<TaskToDo?> DeleteById(int id) //DeleteTaskToDo
        {
            var result = await _dataContext.TasksToDo
                .FirstOrDefaultAsync(t => t.TaskToDoId == id);

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
