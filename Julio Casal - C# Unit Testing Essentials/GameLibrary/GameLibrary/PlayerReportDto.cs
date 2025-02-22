namespace GameLibrary;

public record PlayerReportDto(
    string PlayerName,
    int Level,
    DateTime JoinDate,
    int GamesPlayed,
    int TotalScore,
    double AverageScore);