using System.ComponentModel.DataAnnotations;

namespace stackovergol.Data.Entity
{
    public class TeamMatch
    {
        public int TeamMatchId { get; set; }
        [Required]
        public int MatchId { get; set; }
        public virtual Match Match { get; set; }
        [Required]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        [Required]
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
    }
}
