namespace GameLibrary;

public class QuestMaster
{
    private readonly INotificationService notificationService;
    private readonly IQuestGenerator questGenerator;

    public QuestMaster(IQuestGenerator questGenerator, INotificationService notificationService)
    {
        this.notificationService = notificationService;
        this.questGenerator = questGenerator;
    }

    public Quest AssignQuest(PlayerContact playerContact, int questDifficulty)
    {
        var quest = questGenerator.GenerateQuest(questDifficulty);
        quest.SetPlayer(playerContact.Name);

        string message = $"You have been assigned a new quest: {quest.Name}! Complete it to earn {quest.Reward} points.";
        notificationService.NotifyPlayer(playerContact, message);

        return quest;
    }
}
