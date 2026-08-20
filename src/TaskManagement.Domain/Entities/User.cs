namespace TaskManagement.Domain.Entities;

public class User : BaseEntity
{
    public User(string name, string email, string passwordHash)
    {
        Name = GuardName(name);
        Email = GuardEmail(email);
        PasswordHash = GuardPasswordHash(passwordHash);
    }

    public string Name { get; private set; }

    public string Email { get; private set; }

    public string PasswordHash { get; private set; }

    public void UpdateProfile(string name, string email)
    {
        Name = GuardName(name);
        Email = GuardEmail(email);
        Touch();
    }

    public void ChangePassword(string newPasswordHash)
    {
        PasswordHash = GuardPasswordHash(newPasswordHash);
        Touch();
    }

    private static string GuardName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.", nameof(name));

        return name.Trim();
    }

    private static string GuardEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
            throw new ArgumentException("A valid email is required.", nameof(email));

        return email.Trim();
    }

    private static string GuardPasswordHash(string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("Password hash cannot be empty.", nameof(passwordHash));

        return passwordHash;
    }
}
