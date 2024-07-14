using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Validations.ValueObjectsValidators;
using EasyHealth.Domain.ValueObjects;

namespace EasyHealth.Tests.ValueObjects;

public class DocumentTests
{
    private string _firstExpectedMessage = string.Empty;
    private string _secondExpectedMessage = string.Empty;
    private string _thirdExpectedMessage = string.Empty;

    public static List<object[]> InvalidDocuments
        => new()
        {
            new object[] { "516.012.470-53" },
            new object[] { "" },
            new object[] { "241.571.000-86" }
        };

    [Theory]
    [MemberData(nameof(InvalidDocuments))]
    public void ShouldReturnErrorWhenCpfIsInvalid(string cpf)
    {
        //Arrange
        var document = new Document(cpf);
        _firstExpectedMessage = "O campo cpf não pode ser vázio!";
        _secondExpectedMessage = "Cpf no formato inválido!";
        _thirdExpectedMessage = "Cpf inválido!";

        //Act
        var result = document.Validate();

        //Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors,
            e => e.ErrorMessage.Equals("O campo cpf não pode ser vázio!")
                 || e.ErrorMessage.Equals("Cpf no formato inválido!")
                 || e.ErrorMessage.Equals("Cpf inválido!"));
    }

    public static List<object[]> ValidDocuments
        => new()
        {
            new object[] { "516.012.470-52" },
            new object[] { "710.631.380-78" },
            new object[] { "241.571.000-85" }
        };

    [Theory]
    [MemberData(nameof(ValidDocuments))]
    public void ShouldReturnSuccessWhenCpfIsValid(string cpf)
    {
        //Arrange
        var document = new Document(cpf);

        //Act
        var result = document.Validate();

        //Assert
        Assert.True(result.IsValid);
    }
}