namespace GameLibrary.UnitTests
{
    public class TreasureChestTests
    {
        //MethodName_StateUnderTest_ExpectedBehavior

        [Fact]
        public void CanOpen_ChestIsLockedAndHasKey_ReturnsTrue()
        {
            
            var chest = new TreasureChest(true);

            var result = chest.CanOpen(true);

            Assert.True(result);
        }
    }
}
