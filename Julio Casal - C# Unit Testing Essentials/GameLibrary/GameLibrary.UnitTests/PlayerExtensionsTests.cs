using FluentAssertions;

namespace GameLibrary.UnitTests
{
    public class PlayerExtensionsTests
    {
        [Fact]
        public void ToDto_WhenCalled_MapsProperties()
        {
            // Arrange
            var sut = new Player("Alice", 1, DateTime.Now);
            var item = new InventoryItem(101, "Sword", "A sharp blade.");
            sut.AddItemToInventory(item);

            // Act
            var dto = sut.ToDto();

            // Assert
            //Assert.Equivalent(sut, dto);
            dto.Should().BeEquivalentTo(sut, option => option
                              .Excluding(s => s.InventoryItems)
                              .Excluding(s => s.ExperiencePoints)
                              );

            dto.Should().BeEquivalentTo(sut, option => option
                              .ExcludingMissingMembers()
                              );

        }
    }
}
