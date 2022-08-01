namespace ToDoListAPI.Models
{
    public class TaskToDoResponse
    {
        public int Id { get; set; }
        public string? DescriptionText { get; set; }
        public bool IsCompleted { get; set; }

    }
}
