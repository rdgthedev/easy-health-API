using EasyHealth.Domain.ValueObjects;

namespace EasyHealth.Tests.ValueObjects;

public class NameTests
{
    private readonly Name _name;
    private string _firstExpectedMessage;
    private string _secondExpectedMessage;

    public NameTests()
    {
        _name = new Name("Neymar", "Júnior");
        _firstExpectedMessage = string.Empty;
        _secondExpectedMessage = string.Empty;
    }

    [Fact]
    public void ShouldReturnErrorWhenFirstNameIsInvalid()
    {
        //Arrange
        var name = new Name("", "def");
        _firstExpectedMessage = "O primeiro nome não pode ser vazio!";
        _secondExpectedMessage = "O nome deve ter no mínimo três caracteres!";
        //Act
        var result = name.Validate();

        //Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e
            => e.ErrorMessage.Equals(_firstExpectedMessage));
        Assert.Contains(result.Errors, e
            => e.ErrorMessage.Equals(_secondExpectedMessage));
    }

    [Fact]
    public void ShouldReturnSuccessFirstNameValid()
    {
        //Act
        var result = _name.Validate();

        //Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void ShouldReturnWhenLastNameIsInvalid()
    {
        //Arrange
        var name = new Name("abc", "");
        _firstExpectedMessage = "O sobrenome não pode ser vazio!";
        _secondExpectedMessage = "O sobrenome deve ter no mínimo três caracteres!";

        //Act
        var result = name.Validate();

        //Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e
            => e.ErrorMessage.Equals(_firstExpectedMessage));
        Assert.Contains(result.Errors, e
            => e.ErrorMessage.Equals(_secondExpectedMessage));
    }

    [Fact]
    public void ShouldReturnSuccessLastNameValid()
    {
        //Act
        var result = _name.Validate();
        
        //Assert
        Assert.True(result.IsValid);
    }
}