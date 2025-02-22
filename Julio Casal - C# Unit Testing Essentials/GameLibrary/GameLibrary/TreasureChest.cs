namespace GameLibrary;

public class TreasureChest
{
    public TreasureChest(bool isLocked)
    {
        IsLocked = isLocked;
    }

    public bool IsLocked { get; set; }

    public bool CanOpen(bool hasKey)
    {
        if (IsLocked && !hasKey)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
