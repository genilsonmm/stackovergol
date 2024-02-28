using System.ComponentModel.DataAnnotations.Schema;

namespace stackovergol.Data.Entity
{
    public class Match
    {
        public int MatchId { get; set; }
        public DateTime MatchDate { get; set; }
        public int Fhase { get; set; }

        public int TeamLeftId { get; set; }
        public virtual Team TeamLeft { get; set; }
        public int TeamRightId { get; set; }
        public virtual Team TeamRight { get; set; }
        public int GolLeft { get; set; }
        public int GolRight { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
    }
}
