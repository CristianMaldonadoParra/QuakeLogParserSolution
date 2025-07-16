using Microsoft.AspNetCore.Mvc.Testing;
using QuakerLogParse.Api;
using QuakerLogParse.Application.DTOs;
using System.Net;
using System.Net.Http.Json;

namespace QuakeLogParser.Test
{
    public class GamesControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public GamesControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ParseLog_ShouldReturnGamesReport()
        {
            // Arrange
            string endpoint = $"http://localhost:5000/api/games/parse-log";

            // Act
            var response = await _client.GetAsync(endpoint);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var games = await response.Content.ReadFromJsonAsync<List<GameDto>>();
            Assert.NotNull(games);
            Assert.NotEmpty(games);

            var game1 = games.FirstOrDefault(g => g.Name == "game_1");
            Assert.NotNull(game1);
            Assert.Equal(0, game1.TotalKills);
            Assert.Empty(game1.Players);
        }
    }
}
