namespace stackovergol.Dto
{
    public class PlayerResponseDTO
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Rating { get; set; }
        public string Photo { get; set; }
        public bool IsMember { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsGoalkeeper { get; set; }
        public bool Enabled { get; set; }
    }
}
