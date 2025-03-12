namespace GameLibrary;

internal class TreasureChest
{
    internal TreasureChest(bool isLocked)
    {
        IsLocked = isLocked;
    }

    internal bool IsLocked { get; set; }

    internal bool CanOpen(bool hasKey)
    {
        return !IsLocked || hasKey;
    }
}
