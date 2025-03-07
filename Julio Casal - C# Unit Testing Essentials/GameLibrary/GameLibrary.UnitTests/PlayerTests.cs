using FluentAssertions;

namespace GameLibrary.UnitTests
{
    public class PlayerTests
    {
        [Fact]
        public void IncreaseLevel_WhenCalled_HasExpectedLevel()
        {
            // Arrange
            Player sut = new("Alice", 1, DateTime.Now);

            // Act
            sut.IncreaseLevel();

            //Assert
            //Assert.Equal(2, sut.Level);
            sut.Level.Should().Be(2);
            sut.Level.Should().BeGreaterThan(1);
            sut.Level.Should().BeLessThanOrEqualTo(2);
            sut.Level.Should().BePositive();
            sut.Level.Should().NotBe(1);

            //Assert.InRange(sut.Level, 2, 100);
            sut.Level.Should().BeInRange(2, 100);
        }

        [Fact]
        public void Greet_ValidGreeting_ReturnsGreetingWithName()
        {
            // Arrange
            Player sut = new("Lynia", 1, DateTime.Now);

            // Act
            var result = sut.Greet("Hello");

            // Assert

            //Assert.Equal("Hello, Lynia!", result);
            result.Should().Be("Hello, Lynia!");

            //Assert.Contains("Lynia",result);
            result.Should().Contain("Lynia");

            //Assert.EndsWith("Lynia!", result);
            result.Should().EndWith("Lynia!");

            //Assert.NotNull(result);
            result.Should().NotBeNull();

            //Assert.NotEmpty(result);
            result.Should().NotBeEmpty();
        }

        [Fact]

        public void Constructor_OnNewInstance_SetsJoinDate()
        {
            // Arrange
            var currentDate = DateTime.Now;

            // Act
            var sut = new Player("MPl", 1, currentDate);

            // Assert

            //Assert.Equal(currentDate, sut.JoinDate);
            sut.JoinDate.Should().Be(currentDate);
            sut.JoinDate.Should().BeCloseTo(currentDate, TimeSpan.FromMilliseconds(500));
            sut.JoinDate.Should().BeWithin(TimeSpan.FromMilliseconds(500)).Before(currentDate);
        }
    }
}
