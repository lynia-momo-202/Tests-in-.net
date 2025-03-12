namespace GameLibrary;

public class QuestGenerator
{
    private readonly double rewardMultiplier;

    public QuestGenerator(double rewardMultiplier = 1.0)
    {
        this.rewardMultiplier = rewardMultiplier;
    }

    public Quest GenerateQuest(int questDifficulty)
    {
        int reward = CalculateQuestReward(questDifficulty);
        string name = $"Quest Level {questDifficulty}";
        return new Quest(name, reward);
    }

    private int CalculateQuestReward(int questDifficulty)
    {
        return (int)(questDifficulty * 100 * rewardMultiplier);
    }
}