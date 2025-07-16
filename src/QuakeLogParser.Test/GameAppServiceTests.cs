using Moq;
using QuakerLogParse.Application.Interfaces;
using QuakerLogParse.Application.Services;
using QuakerLogParse.Domain.Entities;
using QuakerLogParse.Domain.Interfaces;

namespace QuakeLogParser.Test
{
    public class GameAppServiceTests
    {

        private readonly Mock<ILogParserAppService> _logParserServiceMock;
        private readonly IGameAppService _gameAppService;

        public GameAppServiceTests()
        {
            _logParserServiceMock = new Mock<ILogParserAppService>();
            _gameAppService = new GameAppService(_logParserServiceMock.Object);
        }

        [Fact]
        public void GetReports_ShouldReturnMappedDtos_WhenLogParserReturnsGames()
        {
            // Arrange
            var fakeGames = new List<Game>
            {
                new Game
                {
                    Name = "game_1",
                    TotalKills = 3,
                    Players = new List<string> { "Player1", "Player2" },
                    Kills = new Dictionary<string, int>
                    {
                        { "Player1", 2 },
                        { "Player2", 1 }
                    }
                }
            };

            _logParserServiceMock.Setup(x => x.ParseLog(It.IsAny<string>()))
                                 .Returns(fakeGames);

            // Act
            var result = _gameAppService.GetReports("fakepath");

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);

            var gameDto = result[0];
            Assert.Equal("game_1", gameDto.Name);
            Assert.Equal(3, gameDto.TotalKills);
            Assert.Contains("Player1", gameDto.Players);
            Assert.Contains("Player2", gameDto.Players);
            Assert.Equal(2, gameDto.Kills["Player1"]);
            Assert.Equal(1, gameDto.Kills["Player2"]);
        }

        [Fact]
        public void GetReports_ShouldReturnEmptyList_WhenNoGamesParsed()
        {
            // Arrange
            _logParserServiceMock.Setup(x => x.ParseLog(It.IsAny<string>()))
                                 .Returns(new List<Game>());

            // Act
            var result = _gameAppService.GetReports("fakepath");

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}
