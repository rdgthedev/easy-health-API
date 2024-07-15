using EasyHealth.Domain.Entities;
using EasyHealth.Domain.Enums;
using EasyHealth.Domain.ValueObjects;

namespace EasyHealth.Tests.Entities;

public class AppointmentTests
{
    private string _expectedErrorMessage = string.Empty;

    private readonly Name _name = null!;
    private readonly Email _email = null!;
    private readonly Crm _crm = null!;
    private readonly Document _document = null!;
    private readonly Title _title = null!;
    private readonly Specialty _specialty = null!;
    private readonly Address _address = null!;
    private readonly Doctor _doctor = null!;
    private readonly Patient _patient = null!;
    private readonly Exam _exam = null!;
    private readonly Appointment _appointment = null!;

    public AppointmentTests()
    {
        _name = new Name("Bruce", "Wayne");
        _email = new Email("batman@gmail.com");
        _crm = new Crm("123456", "SP");
        _document = new Document("116.919.780-94");
        _title = new Title("teste");
        _specialty = new Specialty("Cardiologista");
        _exam = new Exam("ECG", "exame");

        _address = new Address(
            "teste",
            "Jardim teste",
            32,
            "São Paulo",
            "SP",
            "12345678",
            null);

        _doctor = new Doctor(
            _name,
            DateTime.UtcNow.AddYears(-30),
            EGender.Male,
            _address,
            _email,
            _crm,
            _specialty,
            _document);

        _patient = new Patient(
            _name,
            _email,
            _address,
            _document,
            DateTime.UtcNow.AddYears(-15),
            EGender.Female);

        _appointment = new Appointment(
            _doctor, 
            _patient, 
            _exam, 
            DateTime.UtcNow);
    }

    [Fact]
    public void ShouldReturnErrorAppointmentIsInvalid()
    {
        //Arrange
        _expectedErrorMessage = "O campo data não pode conter uma data no futura!";
        var appointment = new Appointment(_doctor, _patient, _exam, DateTime.Now.AddDays(2));

        //Act
        var result = appointment.Validate();

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors,
            e => e.ErrorMessage.Equals(_expectedErrorMessage));
    }

    [Fact]
    public void ShouldReturnSuccessAppointmentIsValid()
    {
        //Act
        var result = _appointment.Validate();
        
        //Assert
        Assert.True(result.IsValid);
    }
}