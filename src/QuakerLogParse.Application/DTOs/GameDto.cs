using QuakerLogParse.Domain.Entities;

namespace QuakerLogParse.Application.DTOs
{
    public class GameDto
    {
        public string Name { get; set; } = string.Empty;
        public int TotalKills { get; set; }
        public List<string> Players { get; set; }
        public Dictionary<string, int> Kills { get; set; }

        public static GameDto FromEntity(Game entity)
        {
            return new GameDto
            {
                Name = entity.Name,
                TotalKills = entity.TotalKills,
                Players = entity.Players.Distinct().ToList(),
                Kills = new Dictionary<string, int>(entity.Kills)
            };
        }
    }
}
