namespace ToDoListAPI.Models
{
    public class TaskToDoResponse
    {
        public int TaskToDoResponseId { get; set; }
        public string? DescriptionText { get; set; }
        public bool IsCompleted { get; set; }

    }
}
