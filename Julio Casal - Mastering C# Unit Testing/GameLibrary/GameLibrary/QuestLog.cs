namespace GameLibrary;

public class QuestLog
{
    public List<string> Quests { get; private set; }

    public QuestLog(string initialQuest)
    {
        Quests = new(){ initialQuest };
    }

    public bool AddQuest(string quest)
    {
        Quests.Add(quest);
        return true;
    }
}