using FluentAssertions;

namespace GameLibrary.UnitTests;

public class GameCharacterTests
{
    [Fact]
    public void Heal_WithPositiveNumber_IncreasesHealth()
    {
        // Arrange
        var sut = new GameCharacter("Character 1", 1, 1);
        var initialHealth = sut.Health;
        var points = 3;

        // Act
        sut.Heal(points);

        // Assert
        sut.Health.Should().Be(initialHealth + points);
    }

    [Fact]
    public void AddItemToInventory_WithValidItem_IncreasesInventoryCount()
    {
        // Arrange
        var sut = new GameCharacter("Character 1", 1, 1);
        var item = new InventoryItem(1, "Item 1", "Description 1");
        var initialCount = sut.Inventory.Count;

        // Act
        sut.AddItemToInventory(item);

        // Assert
        sut.Inventory.Count.Should().Be(initialCount + 1);
    }

    [Fact]
    public void AddItemToInventory_WhenInventoryIsFull_ThrowsInvalidOperationException()
    {
        // Arrange
        var sut = new GameCharacter("Character 1", 1, 1);

        var items = new List<InventoryItem>();

        for (int i = 0; i < 10; i++)
        {
            sut.AddItemToInventory(new InventoryItem(i, $"Item {i}", $"Description {i}"));
        }

        var newItem = new InventoryItem(11, "Item 11", "Description 11"); // The 11th item

        // Act
        Action act = () => sut.AddItemToInventory(newItem);

        // Assert
        act.Should().Throw<InvalidOperationException>();
    }    
}

