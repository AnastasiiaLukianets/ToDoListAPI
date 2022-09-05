using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Models;

namespace ToDoListAPI.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<User?>> GetAll()
        {
            return await _dataContext.Users.ToListAsync();
        }

        public async Task<User?> GetById(int id)
        {
            return await _dataContext.Users
                .Include(u => u.Tasks)
                .FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<User?> Add(User user)
        {
            var result = await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User?> Update(User user)
        {
            var result = await _dataContext.Users
                .FirstOrDefaultAsync(u => u.UserId == user.UserId);

            if (result != null)
            {
                result.UserName = user.UserName;
                result.Age = user.Age;
                result.Tasks = user.Tasks; // ? any problems

                await _dataContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
        public async Task<User?> DeleteById(int id)
        {
            var result = await _dataContext.Users
                .FirstOrDefaultAsync(u => u.UserId == id);

            if (result != null)
            {
                _dataContext.Users.Remove(result);
                await _dataContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
