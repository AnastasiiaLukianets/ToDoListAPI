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

        public async Task<IEnumerable<TaskToDo?>> GetAll()
        {
            return await _dataContext.TasksToDo.ToListAsync();
        }

        public async Task<TaskToDo?> GetById(int id)
        {
            return await _dataContext.TasksToDo
                .FirstOrDefaultAsync(t => t.TaskToDoId == id);
        }

        public async Task<TaskToDo?> Add(TaskToDo task) 
        {
            var result = await _dataContext.TasksToDo.AddAsync(task);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TaskToDo?> Update(TaskToDo task) 
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
        public async Task<TaskToDo?> DeleteById(int id)
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

        //public async Task<IEnumerable<TaskToDo>> GetAllTasksByUser(int userId)
        //{
        //    var tasks = await _dataContext.TasksToDo
        //        .Where(t => t.UserId == userId)
        //        .ToListAsync();
        //}
    }
}
