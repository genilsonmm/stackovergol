using System.ComponentModel.DataAnnotations.Schema;

namespace stackovergol.Data.Entity
{
    public class Team
    {
        public int TeamId { get; set; }
        public int Name { get; set; }
        public int MatchId { get; set; }
        public virtual Match Match { get; set; }
        public ICollection<Player> Players { get; set; }
    }
}
