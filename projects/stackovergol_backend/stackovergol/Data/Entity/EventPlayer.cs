using System.ComponentModel.DataAnnotations;

namespace stackovergol.Data.Entity
{
    public class EventPlayer
    {
        public int EventPlayerId { get; set; }
        [Required]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
        [Required]
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
        public bool IAmIn { get; set; }
    }
}
