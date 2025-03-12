namespace GameLibrary;

public class GameMatch
{
    public int Id { get; set; }
    
    public required string Player1 { get; set; }
    
    public string? Player2 { get; set; }
    
    public MatchState MatchState { get; set; }
    
    public DateTimeOffset CreatedTime { get; set; }
}

public enum MatchState
{
    WaitingForOpponent,
    MatchFound,
    GameReady
}