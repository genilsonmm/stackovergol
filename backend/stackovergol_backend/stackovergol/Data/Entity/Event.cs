using System.ComponentModel.DataAnnotations;

namespace stackovergol.Data.Entity
{
    public class Event
    {
        public int EventId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
