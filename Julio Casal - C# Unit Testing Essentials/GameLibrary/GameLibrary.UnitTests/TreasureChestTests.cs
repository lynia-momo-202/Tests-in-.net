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
    }
}
