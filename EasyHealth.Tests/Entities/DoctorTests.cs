using EasyHealth.Domain.Entities;
using EasyHealth.Domain.Enums;
using EasyHealth.Domain.ValueObjects;

namespace EasyHealth.Tests.Entities;

public class DoctorTests
{
    private string _firstExpectedMessage = string.Empty;
    private string _secondExpectedMessage = string.Empty;

    private Name _name = null!;
    private Email _email = null!;
    private Crm _crm = null!;
    private Document _document = null!;
    private Doctor _doctor = null!;
    private Title _title = null!;
    private Specialty _specialty = null!;

    public DoctorTests()
    {
        _name = new Name("Bruce", "Wayne");
        _email = new Email("brucewayne@gmail.com");
        _crm = new Crm("123456", "SP");
        _document = new Document("456.969.960-00");
        _crm = new Crm("123456", "SP");
        _title = new Title("teste");
        _specialty = new Specialty(_title);
        _doctor = new Doctor(_name, DateTime.Now.AddYears(-18), EGender.Male, _email, _crm, _specialty, _document);
    }

    [Fact]
    public void ShouldReturnErrorWhenDoctorIsInvalid()
    {
        //Arrange
        _firstExpectedMessage = "O código deve ter seis números!";
        _secondExpectedMessage = "O médico deve ter no mínimo uma especialidade!";

        var name = new Name("Rodrigo", "Ferreira");
        var birthDate = DateTime.Now.AddYears(-18);
        var email = new Email("Rodrigo@gmail.com");
        var crm = new Crm("1234567", "SP");
        var document = new Document("456.969.960-00");
        var doctor = new Doctor(name, birthDate, EGender.Male, email, crm, null!, document);

        //Act

        var result = doctor.Validate();

        //Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors,
            e => e.ErrorMessage.Equals(_firstExpectedMessage));
        Assert.Contains(result.Errors,
            e => e.ErrorMessage.Equals(_secondExpectedMessage));
    }

    [Fact]
    public void ShouldReturnSuccessWhenDoctorIsValid()
    {
        //Act
        var result = _doctor.Validate();

        //Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void ShouldReturnErrorWhenAddingSpecialtyInvalid()
    {
        //Arrange
        var speacialty = new Specialty(_title);

        //Act
        _doctor.AddSpecialty(speacialty);
        var result = _doctor.Validate();

        //Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e
            => e.ErrorMessage.Equals("O médico não pode possuir especialidades repetidas!"));
    }

    [Fact]
    public void ShouldReturnSuccessWhenAddingSpecialtyValid()
    {
        //Arrange
        var specialty = new Specialty("teste2");

        //Act
        _doctor.AddSpecialty(specialty);
        var result = _doctor.Validate();

        //Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void ShouldReturnErrorWhenUpdateIsInvalid()
    {
        //Arrange
        _firstExpectedMessage = "O CRM não pode ser vázio!";
        _secondExpectedMessage = "O campo estado deve ter no mínimo dois caracteres!";
        
        //Act
        _doctor.Update(new Crm("123456", ""), _doctor.Email, _doctor.Address);
        var result = _doctor.Validate();

        //Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors,
            e => e.ErrorMessage.Equals(_firstExpectedMessage)
                 || e.ErrorMessage.Equals(_secondExpectedMessage));
    }

    [Fact]
    public void ShouldReturnErrorWhenUpdateIsValid()
    {
        //Act
        _doctor.Update(new Crm("123456", "SP"), _doctor.Email, _doctor.Address);
        var result = _doctor.Validate();
        
        //Assert
        Assert.True(result.IsValid);
    }
}