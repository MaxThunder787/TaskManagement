using TaskManagement.Domain.Entities;

namespace TaskManagement.UnitTests.Domain;

public class UserTests
{
    [Fact]
    public void User_CanBeCreated()
    {
        var user = new User("Alice", "alice@example.com", "hash");

        Assert.Equal("Alice", user.Name);
        Assert.Equal("alice@example.com", user.Email);
        Assert.Equal("hash", user.PasswordHash);
        Assert.NotEqual(Guid.Empty, user.Id);
        Assert.NotEqual(default, user.CreatedAt);
    }
}
