using TestApp.Functionality;
using Xunit;

namespace TestApp.Test;

public class UserManagementTest
{
    [Fact]
    public void AddUser_CreateUser()
    {
        // Arrange
        UserManagement userManagement = new UserManagement();

        // Act
        userManagement.AddUser(new("John", "Doe"));

        // Assert
        var savedUser = Assert.Single(userManagement.AllUsers);
        Assert.NotNull(savedUser);
        Assert.Equal("John", savedUser.firstName);
        Assert.Equal("Doe", savedUser.lastName);
        Assert.False(savedUser.VerifiedEmail);
    }

    [Fact]
    public void UpdatePhone_Update()
    {
        // Arrange
        UserManagement userManagement = new UserManagement();

        // Act
        userManagement.AddUser(new("John", "Doe"));
        var user = userManagement.AllUsers.First();
        user.PhoneNumber = "123";
        userManagement.UpdatePhone(user);
        
        // Assert
        var savedUser = Assert.Single(userManagement.AllUsers);
        Assert.NotNull(savedUser);
        Assert.Equal("123", savedUser.PhoneNumber);
    }

    [Fact]
    public void VerifyEmail_Verifye()
    {
        // Arrange
        UserManagement userManagement = new UserManagement();

        // Act
        userManagement.AddUser(new("John", "Doe"));
        userManagement.VerifyEmail(1);

        // Assert
        var savedUser = Assert.Single(userManagement.AllUsers);
        Assert.NotNull(savedUser);
        Assert.True(savedUser.VerifiedEmail);
    }
}
