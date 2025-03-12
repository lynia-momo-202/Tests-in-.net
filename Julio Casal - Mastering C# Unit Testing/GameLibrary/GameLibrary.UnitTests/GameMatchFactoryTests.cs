using FluentAssertions;

namespace GameLibrary.UnitTests;

public class GameMatchFactoryTests
{
    [Fact]
    public void CreateMatch_WhenOnWeekend_CreatesMatch()
    {
        // Arrange
        var sut = new GameMatchFactory();

        // Act
        GameMatch match = sut.CreateMatch("A Match");

        // Assert
        match.Should().NotBeNull();
    }

    [Fact]
    public void CreateMatch_WhenOnWeekday_Throws()
    {
        // Arrange
        var sut = new GameMatchFactory();

        // Act
        Action act = () => sut.CreateMatch("A Match");

        // Assert
        act.Should().Throw<InvalidOperationException>();
    }
}

