using Xunit.Abstractions;

namespace GameLibrary.UnitTests
{
    public class TreasureChestTests : IDisposable
    {
        private readonly Stack<TreasureChest> chests;
        private readonly ITestOutputHelper output;

        public TreasureChestTests(ITestOutputHelper output)
        {
            chests = new();
            this.output = output;
            output.WriteLine($"Initial chest count:{chests.Count}");
        }

        //MethodName_StateUnderTest_ExpectedBehavior

        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, false, false)]
        [InlineData(false, true, true)]
        [InlineData(false, false, true)]
        public void CanOpen_WhenCalled_ReturnsExpcetedOutcome(
            bool isLocked,
            bool haskey,
            bool expected)
        {
            // Arange
            var sut = new TreasureChest(isLocked);
            chests.Push(sut);
            output.WriteLine($"Chest count: {chests.Count}");

            // Act
            var actual = sut.CanOpen(haskey);

            // Assert
            Assert.Equal(expected, actual);
            Assert.Single(chests);
        }

        [Fact (Skip = "This test is not ready yet")]
        public void CanOpen_ChestIsLockedAndHasKey_ReturnsTrue()
        {
            // Arange
            var sut = new TreasureChest(true);
            chests.Push(sut);//ajouter le system test dans la pile
            output.WriteLine($"Chest count: {chests.Count}");

            // Act
            var result = sut.CanOpen(true);

            // Assert
            Assert.True(result);
            Assert.Single(chests);//verifier qu'il y a qu'un seul elmt dans la pile
        }

        [Fact(Skip = "This test is not ready yet")]
        public void ConOpen_ChestIsLockedAndHasNoKey_ReturnsFalse()
        {
            // Arrange
            var sut = new TreasureChest(true);
            chests.Push(sut);
            output.WriteLine($"Chest count: {chests.Count}");

            // Act
            var result = sut.CanOpen(false);

            // assert
            Assert.False(result);
            Assert.Single(chests);
        }

        [Fact(Skip = "This test is not ready yet")]
        public void CanOpen_ChestInUnLockedAndHasKey_ReturnsTrue()
        {
            //Arrange
            var sut = new TreasureChest(false);
            chests.Push(sut);
            output.WriteLine($"Chest count: {chests.Count}");

            //Act
            var result = sut.CanOpen(true);

            //assert
            Assert.True(result);
            Assert.Single(chests);
        }

        [Fact(Skip = "This test is not ready yet")]
        public void CanOpen_ChestInUnLockedAndHasNoKey_ReturnsTrue()
        {
            //Arrange
            var sut = new TreasureChest(false);
            chests.Push(sut);
            output.WriteLine($"Chest count: {chests.Count}");

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
            output.WriteLine($"final chest count: {chests.Count}");
        }
    }
}
/// lors de l'execution des tests .net , on ne retoune rien .
/// pour faciliter le retour des element stocke dans le outout apres ou pdt un test , on utilise la commande
/// dotnet test --logger "console;verbosity=detailed"