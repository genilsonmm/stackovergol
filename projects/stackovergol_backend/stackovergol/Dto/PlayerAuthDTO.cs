namespace stackovergol.Dto
{
    public class PlayerAuthDTO
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Rating { get; set; }
        public string Role { get; set; }
        public bool IsGoalkeeper { get; set; }
        public bool Enabled { get; set; }
    }
}
