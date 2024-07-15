using EasyHealth.Domain.Entities;

namespace EasyHealth.Tests.Entities;

public class RoleTests
{
    private string _expectedErrorMessage = string.Empty;

    [Fact]
    public void ShouldReturnErrorWhenRoleIsInvalid()
    {
        //Arrange
        _expectedErrorMessage = "O título deve ter no mínimo três letras!";
        var role = new Role("te");

        //Act
        var result = role.Validate();

        //Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors,
            e => e.ErrorMessage.Equals(_expectedErrorMessage));
    }

    [Fact]
    public void ShouldReturnSuccessWhenRoleIsValid()
    {
        //Arrange
        var role = new Role("teste");
        
        //Act
        var result = role.Validate();

        //Assert
        Assert.True(result.IsValid);
    }
}