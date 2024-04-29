namespace stackovergol.Dto
{
    public class PlayerDTO
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Rating { get; set; }
        public bool IsMember { get; set; }
        public bool IsAdmin { get; set; }
    }
}
