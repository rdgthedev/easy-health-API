using EasyHealth.Domain.Entities;

namespace EasyHealth.Application.Commands;

public class CreateEmployeeCommand
{
    public CreateEmployeeCommand(
        string firstName,
        string lastName,
        string gender,
        string document,
        string street,
        string neighbordhood,
        int number,
        string? complement,
        string zipCode,
        string city,
        string state,
        string email,
        string sector,
        Role role)
    {
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        Document = document;
        Street = street;
        Neighbordhood = neighbordhood;
        Number = number;
        Complement = complement;
        ZipCode = zipCode;
        City = city;
        State = state;
        Email = email;
        Sector = sector;
        Role = role;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Gender { get; private set; }
    public string Document { get; private set; }
    public string Street { get; private set; }
    public string Neighbordhood { get; private set; }
    public int Number { get; private set; }
    public string? Complement { get; private set; }
    public string ZipCode { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Email { get; private set; }
    public string Sector { get; private set; }
    public Role Role { get; private set; }
}