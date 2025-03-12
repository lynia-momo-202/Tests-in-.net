namespace GameLibrary;

public interface INotificationService
{
    void NotifyPlayer(PlayerContact contact, string message);
}
