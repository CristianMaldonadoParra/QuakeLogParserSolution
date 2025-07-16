using QuakerLogParse.Application.Interfaces;
using QuakerLogParse.Application.Services;

namespace QuakeLogParser.Test
{
    public class GameAppService2Tests
    {
        private readonly ILogParserAppService _logParserService;
        private readonly IGameAppService _gameAppService;
        private readonly string _logFilePath = "Resources/games.log";

        public GameAppService2Tests()
        {
            _logParserService = new LogParserAppService();
            _gameAppService = new GameAppService(_logParserService);
        }

        [Fact]
        public void GetReports_ShouldReturnExpectedGamesData()
        {
            // Act
            var result = _gameAppService.GetReports(_logFilePath);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Count >= 1, "Deveria ter pelo menos um jogo parseado");

            // Exemplo de validação para game_1
            var game1 = result.FirstOrDefault(g => g.Name == "game_1");
            Assert.NotNull(game1);
            Assert.Equal(0, game1.TotalKills);
            Assert.Empty(game1.Players);
            Assert.Empty(game1.Kills);

            // Validação para game_3
            var game3 = result.FirstOrDefault(g => g.Name == "game_3");
            Assert.NotNull(game3);
            Assert.Equal(4, game3.TotalKills);

            var expectedPlayersGame3 = new List<string> { "Isgalamido", "Mocinha", "Zeh", "Dono da Bola" };
            Assert.All(expectedPlayersGame3, player => Assert.Contains(player, game3.Players));

            Assert.Equal(1, game3.Kills["Isgalamido"]);
            Assert.Equal(-2, game3.Kills["Zeh"]);
            Assert.Equal(-1, game3.Kills["Dono da Bola"]);

            // Validação geral para todos os jogos
            foreach (var game in result)
            {
                Assert.False(string.IsNullOrEmpty(game.Name), "O nome do jogo não pode ser vazio");
                Assert.True(game.TotalKills >= 0, "Total de kills não pode ser negativo");

                if (game.Players.Any())
                {
                    Assert.All(game.Players, player => Assert.False(string.IsNullOrEmpty(player), "Nome do player não pode ser vazio"));
                }

                if (game.Kills.Any())
                {
                    Assert.All(game.Kills, kill => Assert.False(string.IsNullOrEmpty(kill.Key), "Nome do player no dicionário de kills não pode ser vazio"));
                }
            }
        }
    }
}
