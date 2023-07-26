namespace TodoApi.Entity
{
    public class TodoItem
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueBy { get; set; }
        public bool Completed { get; set; }
    }
}
