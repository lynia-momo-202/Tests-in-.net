using FluentAssertions;

namespace GameLibrary.UnitTests;

public class QuestLogTests
{
    [Fact]
    public void AddQuest_WhenCalled_AddsQuestToLog()
    {
        // Arrange
        var sut = new QuestLog("Initial Quest");
        
        // Act
        sut.AddQuest("Second Quest");

        // Assert
        var lastQuest = sut.Quests.Last();
        lastQuest.Should().Be("Second Quest");
    }
}
