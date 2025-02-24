namespace GameLibrary.UnitTests
{
    public class TreasureChestTests
    {
        //MethodName_StateUnderTest_ExpectedBehavior

        [Fact]
        public void CanOpen_ChestIsLockedAndHasKey_ReturnsTrue()
        {
            // Arange
            var sut = new TreasureChest(true);

            // Act
            var result = sut.CanOpen(true);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ConOpen_ChestIsLockedAndHasNoKey_ReturnsFalse()
        {
            // Arrange
            var sut = new TreasureChest(true);

            // Act
            var result = sut.CanOpen(false);

            // assert
            Assert.False(result);
        }

        [Fact]
        public void CanOpen_ChestInUnLockedAndHasKey_ReturnsTrue()
        {
            //Arrange
            var sut = new TreasureChest(false);

            //Act
            var result = sut.CanOpen(true);

            //assert
            Assert.True(result);
        }

        [Fact]
        public void CanOpen_ChestInUnLockedAndHasNoKey_ReturnsTrue()
        {
            //Arrange
            var sut = new TreasureChest(false);

            //Act
            var result = sut.CanOpen(false);

            //assert
            Assert.True(result);
        }
    }
}
