using EasyHealth.Domain.Validations.ValueObjectsValidators;
using EasyHealth.Domain.ValueObjects;

namespace EasyHealth.Tests.ValueObjects;

public class CrmTests
{
    private readonly Crm _crm;

    public CrmTests()
    {
        _crm = new Crm("123456", "SP");
    }

    [Fact]
    public void ShouldReturnErrorWhenCrmIsInvalid()
    {
        //Arrange
        var crm = new Crm("1", "SP");

        //Act
        var isValid = new CrmValidator().Validate(crm).IsValid;

        //Assert
        Assert.False(isValid);
    }

    [Fact]
    public void ShouldReturnSuccessWhenCrmIsValid()
    {
        //Act
        var isValid = new CrmValidator().Validate(_crm).IsValid;

        //Assert
        Assert.True(isValid);
    }

    [Fact]
    public void ShouldReturnSuccessWhenPassingACrmToAString()
    {
        //Arrange
        string crm = _crm;

        //Act + Assert
        Assert.Equal(_crm.ToString(), crm);
    }
}