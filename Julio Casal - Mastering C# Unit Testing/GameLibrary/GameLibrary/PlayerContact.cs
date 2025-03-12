namespace GameLibrary;

public class PlayerContact
{
    public string Email { get; }
    public string Name { get; }

    public PlayerContact(string name, string email)
    {
        Name = name;
        Email = email;
    }
}
