namespace GameLibrary;

public class Quest
{
    public string Name { get; }
    public int Reward { get; }
    public string? PlayerName { get; private set; }

    public Quest(string name, int reward)
    {
        Name = name;
        Reward = reward;
    }

    public void SetPlayer(string playerName)
    {
        PlayerName = playerName;
    }
}
