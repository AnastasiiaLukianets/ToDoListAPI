using ToDoListAPI.Models;

namespace ToDoListAPI.ResponseDto
{
    public class UserResponse
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public ICollection<TaskToDo>? Tasks { get; set; }
    }
}
