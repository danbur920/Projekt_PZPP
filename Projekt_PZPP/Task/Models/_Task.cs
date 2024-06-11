namespace Task.Models
{
    public class _Task
    {
        public int Id { get; set; }
        public int? ListId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? Deadline { get; set; }
        public string? State { get; set; }
    }
}