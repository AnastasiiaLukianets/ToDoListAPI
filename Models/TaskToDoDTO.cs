namespace ToDoListAPI.Models
{
    public class TaskToDoDTO
    {
        public int Id { get; set; }
        public string? DescriptionText { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }
    }
}
