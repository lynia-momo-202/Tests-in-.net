namespace GameLibrary;

public class GameCharacter
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int Health { get; set; }
    public List<InventoryItem> Inventory { get; set; }

    public GameCharacter(string name, int level, int health)
    {
        Name = name;
        Level = level;
        Health = health;
        Inventory = new List<InventoryItem>();
    }

    public void Heal(int points)
    {
        Health += points;
    }

    public void AddItemToInventory(InventoryItem item)
    {
        if (Inventory.Count == 10)
        {
            throw new InvalidOperationException("Inventory is full");
        }

        Inventory.Add(item);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}

