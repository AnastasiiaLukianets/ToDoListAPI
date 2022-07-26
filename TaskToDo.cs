namespace ToDoListAPI
{
    public class TaskToDo
    {
        public int Id { get; set; }
        //public string Title { get; set; } = string.Empty;
        public string? DescriptionText { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }
    }
}
