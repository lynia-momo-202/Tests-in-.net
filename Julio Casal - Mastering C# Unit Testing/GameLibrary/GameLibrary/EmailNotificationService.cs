using System.Net.Mail;

namespace GameLibrary;

public class EmailNotificationService : INotificationService
{
    public void NotifyPlayer(PlayerContact contact, string message)
    {
        using (var smtpClient = new SmtpClient("smtp.your-game.com"))
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("no-reply@your-game.com"),
                Subject = "New Game Notification",
                Body = message,
            };
            mailMessage.To.Add(contact.Email);

            smtpClient.Send(mailMessage);
        }
    }
}
