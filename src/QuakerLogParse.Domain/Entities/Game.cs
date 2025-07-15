namespace QuakerLogParse.Domain.Entities
{
    public class Game
    {
        public string Name { get; set; } = string.Empty;
        public int TotalKills { get; set; }
        public List<string> Players { get; set; } = new();
        public Dictionary<string, int> Kills { get; set; } = new();
    }
}
