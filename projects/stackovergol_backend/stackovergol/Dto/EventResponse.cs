namespace stackovergol.Dto
{
    public class EventResponse
    {
        public int EventId { get; set; }
        public string Date { get; set; }
        public Dictionary<string, List<PlayerResponseDTO>> Players { get; set; }
    }
}
