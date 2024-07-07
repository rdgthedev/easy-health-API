using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Shared;

namespace EasyHealth.Domain.Entities;

public class Patient : BaseEntity
{
    protected Patient()
    {
    }

    public Patient(
        string name,
        string email,
        DateTime birthDate,
        Gender gender)
    {
        Name = name;
        Email = email;
        BirthDate = birthDate;
        Gender = gender;
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public Gender Gender { get; private set; }

    public bool IsValid() => true;

    public void ChangeEmail()
    {
    }
}