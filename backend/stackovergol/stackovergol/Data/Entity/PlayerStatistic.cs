using System.ComponentModel.DataAnnotations;

namespace stackovergol.Data.Entity
{
    public class PlayerMatchStatistic
    {
        public int PlayerMatchStatisticId { get; set; }

        [Required]
        public int PlayerId { get; set; }
        public virtual Player? Player { get; set; }

        [Required]
        public int MatchId { get; set; }
        public virtual Match? Match { get; set; }

        public int Gols { get; set; }
        public int Winners { get; set; }
        public int Losers { get; set; }
    }
}
