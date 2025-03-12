namespace GameLibrary;

public class Player
{
    private readonly List<InventoryItem> inventoryItems = new();

    public string Name { get; }
    public int Level { get; private set; }
    public DateTime JoinDate { get; }
    public IReadOnlyList<InventoryItem> InventoryItems => inventoryItems.AsReadOnly();
    public int ExperiencePoints { get; private set; }

    public event EventHandler? LevelUp;

    public Player(string name, int level, DateTime joinDate)
    {
        Name = name;
        Level = level;
        JoinDate = joinDate;
    }

    public void IncreaseLevel()
    {
        Level++;
        LevelUp?.Invoke(this, EventArgs.Empty);
    }

    public void AddItemToInventory(InventoryItem item)
    {
        inventoryItems.Add(item);
    }

    public DateTime GetJoinYearAndMonth()
    {
        return new DateTime(JoinDate.Year, JoinDate.Month, 1);
    }

    public string Greet(string greeting)
    {
        ArgumentException.ThrowIfNullOrEmpty(greeting, nameof(greeting));

        return $"{greeting}, {Name}!";
    }

    public void GrantExperiencePoints(int taskDifficulty, int timeTaken)
    {
        ExperiencePoints += taskDifficulty * 100 / timeTaken;
    }
}