namespace GameLibrary;

public class GameMatchFactory
{
    private int nextMatchId = 1;

    public GameMatch CreateMatch(string player)
    {
        var now = DateTimeOffset.UtcNow;

        if (now.DayOfWeek != DayOfWeek.Saturday && now.DayOfWeek != DayOfWeek.Sunday)
        {
            throw new InvalidOperationException("Can't create matches on weekdays!");
        }

        return new GameMatch
        {
            Id = nextMatchId++,
            Player1 = player,
            MatchState = MatchState.WaitingForOpponent,
            CreatedTime = now
        };
    }
}
