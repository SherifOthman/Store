using Store.Domain.Entities.Users;
using Xunit;

namespace Store.Domain.Tests;

public class UserTests
{
    [Fact]
    public void Create_ValidParameters_ReturnsUser()
    {
        // Arrange
        var firstName = "Sherif";
        var lastName = "Ali";
        var email = "sherif@gmail.com";
        var hashedPassword = "hashedPassword123";
        var phoneNumber = "12345678910";

        // Act
        var user = User.Create(firstName, lastName, email, hashedPassword, phoneNumber);

        // Assert
        Assert.NotNull(user);
        Assert.Equal(firstName, user.FirstName);
        Assert.Equal(lastName, user.LastName);
        Assert.Equal(email, user.Email);
        Assert.Equal(hashedPassword, user.HashedPassword);
        Assert.Equal(phoneNumber, user.PhoneNumber);
        Assert.False(user.IsDeleted);
        Assert.True((DateTime.UtcNow - user.CreatedOn).TotalSeconds < 1);
    }

    [Theory]
    [InlineData("", "Ali", "sherif@gmail.com", "hashedPassword123", "12345678910")]
    [InlineData("Sherif", "", "sherif@gmail.com", "hashedPassword123", "12345678910")]
    [InlineData("Sherif", "Ali", "invalid-email", "hashedPassword123", "12345678910")]
    [InlineData("Sherif", "Ali", "sherif@gmail.com", "", "12345678910")]
    [InlineData("Sherif", "Ali", "sherif@gmail.com", "hashedPassword123", "")]
    public void Create_InvalidParameters_ThrowsArgumentException(string firstName, string lastName, string email, string password, string phoneNumber)
    {
        Assert.Throws<ArgumentException>(() => User.Create(firstName, lastName, email, password, phoneNumber));
    }

    [Fact]
    public void ChangeEmail_InvalidEmail_ThrowsArgumentException()
    {
        // Arrange
        var user = User.Create("Sherif", "Ali", "sherif@gmail.com", "hashedPassword123", "12345678910");

        // Assert
        Assert.Throws<ArgumentException>(() => user.ChangeEmail("invalid-email"));
    }

    [Fact]
    public void ChangeEmail_ValidEmail_UpdatesEmail()
    {
        // Arrange
        var user = User.Create("Sherif", "Ali", "sherif@gmail.com", "hashedPassword123", "12345678910");
        var newEmail = "newemail@gmail.com";

        // Act
        user.ChangeEmail(newEmail);

        // Assert
        Assert.Equal(newEmail, user.Email);
    }

    [Theory]
    [InlineData("", "Ali")]
    [InlineData("Sherif", "")]
    public void ChangeName_InvalidName_ThrowsArgumentException(string firstName, string lastName)
    {
        // Arrange
        var user = User.Create("Sherif", "Ali", "sherif@gmail.com", "hashedPassword123", "12345678910");

        // Assert
        Assert.Throws<ArgumentException>(() => user.ChangeName(firstName, lastName));
    }

    [Fact]
    public void ChangeName_ValidName_UpdatesName()
    {
        // Arrange
        var user = User.Create("Sherif", "Ali", "sherif@gmail.com", "hashedPassword123", "12345678910");

        // Act
        user.ChangeName("Hassan", "Ahmed");

        // Assert
        Assert.Equal("Hassan", user.FirstName);
        Assert.Equal("Ahmed", user.LastName);
    }

    [Fact]
    public void AddRole_ValidRole_AddsRoleToUser()
    {
        // Arrange
        var user = User.Create("Sherif", "Ali", "sherif@gmail.com", "hashedPassword123", "12345678910");
        var role = new Role("Admin");

        // Act
        user.AddRole(role);

        // Assert
        Assert.Contains(role, user.Roles);
    }

    [Fact]
    public void RemoveRole_ExistingRole_RemovesRoleFromUser()
    {
        // Arrange
        var user = User.Create("Sherif", "Ali", "sherif@gmail.com", "hashedPassword123", "12345678910");
        var role = new Role("Admin");
        user.AddRole(role);

        // Act
        user.RemoveRole(role);

        // Assert
        Assert.DoesNotContain(role, user.Roles);
    }

    [Fact]
    public void MarkAsDeleted_SetsIsDeletedToTrue()
    {
        // Arrange
        var user = User.Create("Sherif", "Ali", "sherif@gmail.com", "hashedPassword123", "12345678910");

        // Act
        user.MarkAsDeleted();

        // Assert
        Assert.True(user.IsDeleted);
    }
}
