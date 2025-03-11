namespace GameLibrary
{
    public interface IPlayerStatisticsService
    {
         PlayerStatistics GetPlayerStatistics(string playerName);
         void UpdatePlayerStatistics(PlayerStatistics stats);
    }
}
