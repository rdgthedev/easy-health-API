using EasyHealth.Domain.Entities;

namespace EasyHealth.Tests.Entities;

public class SpecialtyTests
{
    private string _expectedErrorMessage = string.Empty;

    [Fact]
    public void ShouldReturnErrorWhenSpecialtyIsInvalid()
    {
        //Arrange
        _expectedErrorMessage = "O título deve ter no mínimo três letras!";
        var specialty = new Specialty("te");

        //Act
        var result = specialty.Validate();

        //Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors,
            e => e.ErrorMessage.Equals(_expectedErrorMessage));
    }

    [Fact]
    public void ShouldReturnSuccessWhenSpecialtyIsValid()
    {
        //Arrange
        var specialty = new Specialty("teste");
        
        //Act
        var result = specialty.Validate();
        
        Assert.True(result.IsValid);
    }
}