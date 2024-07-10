using EasyHealth.Domain.Validations.ValueObjectsValidators;
using EasyHealth.Domain.ValueObjects;

namespace EasyHealth.Tests.ValuObjects;

public class AddessTests
{
    [Fact]
    public void ShouldReturnErrorWhenAddressIsInvalid()
    {
        //Arrange
        var address = new Address(
            "a",
            "jardim teste",
            1,
            "cidade",
            "SP",
            null);
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
            "");
        //Act
        var isValid = new AddressValidator().Validate(address).IsValid;
        
        // Assert
        Assert.True(isValid);
    }
}