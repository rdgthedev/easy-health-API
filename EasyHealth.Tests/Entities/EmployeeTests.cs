using EasyHealth.Domain.Entities;
using EasyHealth.Domain.Enums;
using EasyHealth.Domain.ValueObjects;

namespace EasyHealth.Tests.Entities;

public class EmployeeTests
{
    private string _firstExpectedMessage = string.Empty;

    private readonly Name _name = null!;
    private readonly Address _address = null!;
    private readonly Email _email = null!;
    private readonly Document _document = null!;
    private readonly Role _role = null!;
    private readonly Employee _employee = null!;

    public EmployeeTests()
    {
        _name = new Name("Bruce", "Wayne");
        _email = new Email("teste@gmail.com");
        _document = new Document("506.825.490-88");
        _role = new Role("teste");

        _address = new Address(
            "teste",
            "Jardim teste",
            32,
            "São Paulo",
            "SP",
            "12345678",
            null);

        _employee = new Employee(
            _name,
            DateTime.Now.AddYears(-27),
            EGender.Male,
            _address,
            _email,
            "TI",
            _document,
            _role);
    }

    [Fact]
    public void ShouldReturnErrorWhenEmployeeIsInvalid()
    {
        //Arrange
        _firstExpectedMessage = "A idade deve ser pelo menos 18 anos!";
        var employee = new Employee(
            _name,
            DateTime.Now.AddYears(-16),
            EGender.Male,
            _address,
            _email,
            "TI",
            _document,
            null);

        //Act
        var result = employee.Validate();

        //Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors,
            e => e.ErrorMessage.Equals(_firstExpectedMessage));
    }

    [Fact]
    public void ShouldReturnSuccessWhenEmployeeIsValid()
    {
        //Act
        var result = _employee.Validate();

        //Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void ShouldReturnErrorWhenEmployeeUpdateIsInvalid()
    {
        //Act
        _employee.Update(_employee.Email, _employee.Address, _employee.Sector, null!);
        var result = _employee.Validate();

        Assert.False(result.IsValid);
    }

    [Fact]
    public void ShouldReturnSuccessWhenEmployeeUpdateIsValid()
    {
        //Arrange
        var role = new Role("owner");

        //Act
        _employee.Update(_employee.Email, _employee.Address, _employee.Sector, role);
        var result = _employee.Validate();

        Assert.True(result.IsValid);
    }
}