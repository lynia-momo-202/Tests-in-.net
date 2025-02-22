using System.Text.Json;

namespace GameLibrary;

public class FileBasedPlayerStatisticsService
{
    private readonly string filePath;

    public FileBasedPlayerStatisticsService(string filePath)
    {
        this.filePath = filePath;
    }

    public PlayerStatistics GetPlayerStatistics(string playerName)
    {
        var statsDictionary = ReadStatisticsFromFile();

        if (statsDictionary.TryGetValue(playerName, out PlayerStatistics? value))
        {
            return value;
        }

        return new PlayerStatistics { PlayerName = playerName };
    }

    public void UpdatePlayerStatistics(PlayerStatistics stats)
    {
        var statsDictionary = ReadStatisticsFromFile();
        statsDictionary[stats.PlayerName] = stats;
        WriteStatisticsToFile(statsDictionary);
    }

    private Dictionary<string, PlayerStatistics> ReadStatisticsFromFile()
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("Statistics file not found", filePath);
        }

        var json = File.ReadAllText(filePath);
        var statistics = JsonSerializer.Deserialize<Dictionary<string, PlayerStatistics>>(json);
        return statistics ?? new Dictionary<string, PlayerStatistics>();
    }

    private void WriteStatisticsToFile(Dictionary<string, PlayerStatistics> statsDictionary)
    {
        var json = JsonSerializer.Serialize(statsDictionary);
        File.WriteAllText(filePath, json);
    }
}
