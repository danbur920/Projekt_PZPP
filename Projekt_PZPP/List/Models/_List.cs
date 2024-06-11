using System.ComponentModel.DataAnnotations;

namespace List.Models
{
    public class _List
    {
        [Key]
        public int Id { get; set; }
        public int? BoardId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
