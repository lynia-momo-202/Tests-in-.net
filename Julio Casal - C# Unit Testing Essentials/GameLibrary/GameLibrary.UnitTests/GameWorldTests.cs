using FluentAssertions;
using NSubstitute;

namespace GameLibrary.UnitTests
{
    public class GameWorldTests
    {
        [Fact]
        public void GetPlayerReport_PlayerExists_ReturnExpectedReport()
        {
            // Arrange
            var player = new Player("Alice", 1, new DateTime(2020, 1, 1));

            //var playerStatisticsService = new FakePlayerStatisticsService();
            var stats = new PlayerStatistics
            {
                PlayerName = player.Name,
                GamesPlayed = 10,
                TotalScore = 1000
            };
            //playerStatisticsService.UpdatePlayerStatistics(stats);

            var statisticServiceStub = Substitute.For<IPlayerStatisticsService>();
            statisticServiceStub.GetPlayerStatistics(player.Name)
                                .Returns(stats);        

            var expected = new PlayerReportDto
            (
               player.Name,
               player.Level,
               player.JoinDate,
               stats.GamesPlayed,
               stats.TotalScore,
               stats.TotalScore / stats.GamesPlayed
            );

            var sut = new GameWorld(statisticServiceStub);

            // Act
            var actual = sut.GetPlayerReport(player);

            // Assert
            //report.PlayerName.Should().Be("Alice");
            //report.Level.Should().Be(1);
            //report.JoinDate.Should().Be(new DateTime(2020, 1, 1));
            //report.GamesPlayed.Should().Be(10);
            //report.TotalScore.Should().Be(1000);
            //report.AverageScore.Should().Be(100);
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
