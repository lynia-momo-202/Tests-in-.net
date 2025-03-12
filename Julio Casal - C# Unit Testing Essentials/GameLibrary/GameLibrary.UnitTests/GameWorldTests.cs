using FluentAssertions;
using Moq;
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

            //var statisticServiceStub = Substitute.For<IPlayerStatisticsService>();
            //statisticServiceStub.GetPlayerStatistics(player.Name)
            //                    .Returns(stats);        

            var statisticServiceStub = new Mock<IPlayerStatisticsService>();
            statisticServiceStub.Setup(s => s.GetPlayerStatistics(player.Name))
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

            var sut = new GameWorld(statisticServiceStub.Object);

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
        [Fact]
        public void RecordPlayerGameWin_ValidPlayerandScore_UpdatesPlayerStatistics()
        {
            // Arrange
            var player = new Player("Alice", 10, new DateTime(2020, 1, 1));

            var stats = new PlayerStatistics
            {
                PlayerName = player.Name,
                GamesPlayed = 10,
                TotalScore = 1000
            };

            //var statisticServiceMock = Substitute.For<IPlayerStatisticsService>();
            //statisticServiceMock.GetPlayerStatistics(player.Name)
            //    .Returns(stats);
            var statisticServiceMock = new Mock<IPlayerStatisticsService>();
            statisticServiceMock.Setup(s => s.GetPlayerStatistics(player.Name))
            .Returns(stats);

            var sut = new GameWorld(statisticServiceMock.Object);

            // Act
            sut.RecordPlayerGameWin(player,20);

            // Assert
            //statisticServiceMock.Received()
            //    //.UpdatePlayerStatistics(Arg.Any<PlayerStatistics>());
            //    .UpdatePlayerStatistics(Arg.Is<PlayerStatistics>(stats =>
            //    stats.PlayerName == player.Name &&
            //    stats.GamesPlayed == 11 &&
            //    stats.TotalScore == 1020
            //    ));
            statisticServiceMock.Verify(s => s.UpdatePlayerStatistics(It.Is<PlayerStatistics>(stats =>
                            stats.PlayerName == player.Name &&
                            stats.GamesPlayed == 11 &&
                            stats.TotalScore == 1020
                            )));
        }
    }
}
