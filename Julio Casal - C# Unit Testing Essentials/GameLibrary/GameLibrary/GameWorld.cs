namespace GameLibrary;

public class GameWorld
{
    private readonly IPlayerStatisticsService playerStatisticsService;

    public GameWorld(IPlayerStatisticsService playerStatisticsService)
    {
        this.playerStatisticsService = playerStatisticsService;
    }

    public PlayerReportDto GetPlayerReport(Player player)
    {
        var stats = playerStatisticsService.GetPlayerStatistics(player.Name);
        double averageScore = stats.GamesPlayed == 0 ? 0 : (double)stats.TotalScore / stats.GamesPlayed;

        return new PlayerReportDto(
            player.Name,
            player.Level,
            player.JoinDate,
            stats.GamesPlayed,
            stats.TotalScore,
            averageScore
        );
    }

    public void RecordPlayerGameWin(Player player, int score)
    {
        var stats = playerStatisticsService.GetPlayerStatistics(player.Name);
        stats.TotalScore += score;
        stats.GamesPlayed += 1;
        playerStatisticsService.UpdatePlayerStatistics(stats);
    }    
}
