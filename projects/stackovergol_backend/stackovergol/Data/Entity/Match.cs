using System.ComponentModel.DataAnnotations;

namespace stackovergol.Data.Entity
{
    public class Match
    {
        public int MatchId { get; set; }

        [Required]
        public int Fhase { get; set; }

        [Required]
        public int TeamLeftId { get; set; }

        public virtual Team? TeamLeft { get; set; }

        [Required]
        public int TeamRightId { get; set; }

        public virtual Team? TeamRight { get; set; }

        [Required]
        public int EventId { get; set; }

        public virtual Event Event { get; set; }

        [Required]
        public int GolLeft { get; set; }

        [Required]
        public int GolRight { get; set; }        
    }
}
