namespace stackovergol.Data.Entity
{
    public class PlayerMatchStatistic
    {
        public int PlayerMatchStatisticId { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int MatchId { get; set; }
        public Match Match { get; set; }

        public int Gols { get; set; }
        public int Winners { get; set; }
        public int Losers { get; set; }
    }
}
