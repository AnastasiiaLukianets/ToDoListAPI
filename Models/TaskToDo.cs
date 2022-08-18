namespace ToDoListAPI.Models
{
    public class TaskToDo
    {
        public int TaskToDoId { get; set; }
        public string? DescriptionText { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }

        public int? UserId { get; set; }

        public User? User { get; set; }

    }
}
