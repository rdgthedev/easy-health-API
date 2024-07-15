using EasyHealth.Domain.Entities;
using EasyHealth.Domain.Enums;
using EasyHealth.Domain.ValueObjects;

namespace EasyHealth.Tests.Entities;

public class PatientTests
{
    private readonly Name _name;
    private readonly Document _document;
    private readonly Email _email;
    private readonly Address _address;
    private readonly Role _role;

    public PatientTests()
    {
        _name = new Name("Bruce", "Wayne");
        _document = new Document("506.825.490-88");
        _email = new Email("batman@gmail.com");
        _address = new Address(
            "teste",
            "Jardim teste",
            32,
            "São Paulo",
            "SP",
            "12345678",
            null);
    }

    [Fact]
    public void ShouldReturnErrorWhenPatientIsInvalid()
    {
        //Arrange
        var patient = new Patient(_name, _email, _address, _document, new DateTime(), EGender.Female);
        
        //Act
        var result = patient.Validate();
        
        //Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors,
            e => e.ErrorMessage.Equals("O campo data de nascimento não pode ser vázio!"));
    }

    [Fact]
    public void ShouldReturnSuccessWhenPatientIsValid()
    {
        //Arrange
        var patient = new Patient(_name, _email, _address, _document, DateTime.Now.AddYears(-15), EGender.Female);
        
        //Act
        var result = patient.Validate();
        
        //Assert
        Assert.True(result.IsValid);
    }
}