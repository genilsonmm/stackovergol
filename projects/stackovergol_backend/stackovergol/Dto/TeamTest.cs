namespace stackovergol.Dto
{
    public class TeamTest
    {
        public string Name { get; set; } = string.Empty;
        public List<PlayerTest> Players { get; set; } = new();
        public int TotalRating => Players.Sum(p => p.Rating);
    }
}
