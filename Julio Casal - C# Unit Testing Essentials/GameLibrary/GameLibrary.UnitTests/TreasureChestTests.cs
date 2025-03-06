namespace GameLibrary.UnitTests
{
    public class TreasureChestTests : IDisposable
    {
        private readonly Stack<TreasureChest> chests;

        public TreasureChestTests()
        {
            chests = new();
        }

        //MethodName_StateUnderTest_ExpectedBehavior

        [Fact]
        public void CanOpen_ChestIsLockedAndHasKey_ReturnsTrue()
        {
            // Arange
            var sut = new TreasureChest(true);
            chests.Push(sut);//ajouter le system test dans la pile

            // Act
            var result = sut.CanOpen(true);

            // Assert
            Assert.True(result);
            Assert.Single(chests);//verifier qu'il y a qu'un seul elmt dans la pile
        }

        [Fact]
        public void ConOpen_ChestIsLockedAndHasNoKey_ReturnsFalse()
        {
            // Arrange
            var sut = new TreasureChest(true);
            chests.Push(sut);

            // Act
            var result = sut.CanOpen(false);

            // assert
            Assert.False(result);
            Assert.Single(chests);
        }

        [Fact]
        public void CanOpen_ChestInUnLockedAndHasKey_ReturnsTrue()
        {
            //Arrange
            var sut = new TreasureChest(false);
            chests.Push(sut);

            //Act
            var result = sut.CanOpen(true);

            //assert
            Assert.True(result);
            Assert.Single(chests);
        }

        [Fact]
        public void CanOpen_ChestInUnLockedAndHasNoKey_ReturnsTrue()
        {
            //Arrange
            var sut = new TreasureChest(false);
            chests.Push(sut);

            //Act
            var result = sut.CanOpen(false);

            //assert
            Assert.True(result);
            Assert.Single(chests);
        }

        public void Dispose()
        {
            chests.Pop();
            Assert.Empty(chests);
        }
    }
}
