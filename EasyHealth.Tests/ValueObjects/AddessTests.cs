using EasyHealth.Domain.Validations.ValueObjectsValidators;
using EasyHealth.Domain.ValueObjects;

namespace EasyHealth.Tests.ValueObjects;

public class AddessTests
{
    [Fact]
    public void ShouldReturnErrorWhenAddressIsInvalid()
    {
        //Arrange
        var address = new Address(
            "",
            "jardim teste",
            1,
            "cidade",
            "SP",
            "");
        //Act
        var isValid = new AddressValidator().Validate(address).IsValid;

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void ShouldReturnSuccessWhenAddressIsValid()
    {
        //Arrange
        var address = new Address(
            "rua teste",
            "jardim teste",
            1,
            "cidade",
            "SP",
            "12345678");
        //Act
        var isValid = new AddressValidator().Validate(address).IsValid;

        // Assert
        Assert.True(isValid);
    }
}