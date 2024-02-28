using System.ComponentModel.DataAnnotations;

namespace stackovergol.Data.Entity
{
    public class Team
    {
        public int TeamId { get; set; }

        [Required]
        public int Name { get; set; }

        [Required]
        public int MatchId { get; set; }
        public virtual Match? Match { get; set; }

        public ICollection<Player>? Players { get; set; }
    }
}
