using EasyHealth.Domain.ValueObjects;

namespace EasyHealth.Tests.ValueObjects;

public class EmailTests
{
    private string _firstExpectedMessage = string.Empty;
    private string _secondExpectedMessage = string.Empty;

    public static List<object[]> InvalidEmails
        => new()
        {
            new object[] { "@example.com" },
            new object[] { "ola" },
            new object[] { "" }
        };

    [Theory]
    [MemberData(nameof(InvalidEmails))]
    public void ShouldReturnErrorWhenEmailIsInvalid(string address)
    {
        //Arrange
        var email = new Email(address);
        _firstExpectedMessage = "O campo email não pode ser vázio!";
        _secondExpectedMessage = "O e-mail está em um formato inválido!\nExemplo de e-mail válido Ola@exemplo.com";

        //Act
        var result = email.Validate();

        //Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors,
            e => e.ErrorMessage.Equals(_firstExpectedMessage)
                 || e.ErrorMessage.Equals(_secondExpectedMessage));
    }

    public static List<object[]> ValidEmails
        => new()
        {
            new object[] { "rodrigo@example.com" },
            new object[] { "rdgthedev@gmail.com" },
            new object[] { "ola@hotmail.com" }
        };

    [Theory]
    [MemberData(nameof(ValidEmails))]
    public void ShouldReturnSuccessWhenEmailIsvalid(string address)
    {
        //Arrange
        var email = new Email(address);
        _firstExpectedMessage = "O campo email não pode ser vázio!";
        _secondExpectedMessage = "O e-mail está em um formato inválido!\nExemplo de e-mail válido Ola@exemplo.com";
        
        //Act
        var result = email.Validate();
        
        //Assert
        Assert.True(result.IsValid);
    }
}