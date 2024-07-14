using EasyHealth.Domain.Shared;
using EasyHealth.Domain.ValueObjects;

namespace EasyHealth.Tests.ValueObjects;

public class TitleTests : ValueObject
{
    [Fact]
    public void ShouldReturnErrorWhenTitleIsInvalid()
    {
        //Arrange
        var title = new Title("");
        const string firstExpectedMessage = "O título não pode ser vazio!";
        const string secondExpectedMessage = "O título deve ter no mínimo três letras!";
        //Act
        var result = title.Validate();

        //Assert
        Assert.False(result.IsValid);

        Assert.Contains(result.Errors, e
            => e.ErrorMessage is firstExpectedMessage);

        Assert.Contains(result.Errors, e
            => e.ErrorMessage is secondExpectedMessage);
    }

    [Fact]
    public void ShouldSuccessWhenTitleIsValid()
    {
        //Arrange
        var title = new Title("teste");

        //Act
        var result = title.Validate();

        //Assert
        Assert.True(result.IsValid);
    }
}