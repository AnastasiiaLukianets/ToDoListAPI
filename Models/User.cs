namespace ToDoListAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public int Age { get; set; }
        public ICollection<TaskToDo>? Tasks { get; set; }
    }
}
