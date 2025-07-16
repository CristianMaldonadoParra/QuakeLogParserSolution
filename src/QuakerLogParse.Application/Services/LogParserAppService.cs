using QuakerLogParse.Application.Interfaces;
using QuakerLogParse.Domain.Entities;
using System.Text.RegularExpressions;

namespace QuakerLogParse.Application.Services
{
    public class LogParserAppService : ILogParserAppService
    {
        public List<Game> ParseLog(string logFilePath)
        {
            var games = new List<Game>();
            var currentGame = new Game();
            var lines = File.ReadAllLines(logFilePath);
            int gameCounter = 1;

            foreach (var line in lines)
            {
                if (line.Contains("InitGame"))
                {
                    currentGame = new Game { Name = $"game_{gameCounter}" };
                    gameCounter++;
                }
                else if (line.Contains("ShutdownGame"))
                {
                    games.Add(currentGame);
                }
                else if (line.Contains("Kill:"))
                {
                    ParseKill(line, currentGame);
                }
            }

            return games;
        }


        private void ParseKill(string line, Game game)
        {
            var match = Regex.Match(line, @"Kill: \d+ \d+ \d+: (.+) killed (.+) by");

            if (match.Success)
            {
                var killer = match.Groups[1].Value.Trim();
                var victim = match.Groups[2].Value.Trim();

                game.TotalKills++;

                if (killer == "<world>")
                {
                    if (!game.Kills.ContainsKey(victim))
                        game.Kills[victim] = 0;

                    game.Kills[victim]--;
                    game.Players.Add(victim);
                }
                else
                {
                    game.Players.Add(killer);
                    game.Players.Add(victim);

                    if (!game.Kills.ContainsKey(killer))
                        game.Kills[killer] = 0;

                    game.Kills[killer]++;
                }
            }
        }
    }
}
