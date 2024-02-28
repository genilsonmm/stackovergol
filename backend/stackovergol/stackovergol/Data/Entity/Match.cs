using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stackovergol.Data.Entity
{
    public class Match
    {
        public int MatchId { get; set; }

        [Required]
        public DateTime MatchDate { get; set; }

        [Required]
        public int Fhase { get; set; }

        [Required]
        public int TeamLeftId { get; set; }

        public virtual Team? TeamLeft { get; set; }

        [Required]
        public int TeamRightId { get; set; }

        public virtual Team? TeamRight { get; set; }

        [Required]
        public int GolLeft { get; set; }

        [Required]
        public int GolRight { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
    }
}
