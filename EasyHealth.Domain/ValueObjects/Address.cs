using EasyHealth.Domain.Enums;

namespace EasyHealth.Domain.ValueObjects;

public class Address : Shared.ValueObject
{
    public Address(
        string street,
        string neighbordhood,
        int number,
        string city,
        EState state,
        string? complement = null!)
    {
        Street = street;
        Neighbordhood = neighbordhood;
        Number = number;
        Complement = complement;
        City = city;
        State = state;
    }

    public string Street { get; private set; }
    public string Neighbordhood { get; private set; }
    public int Number { get; private set; }
    public string? Complement { get; private set; }
    public string City { get; private set; }
    public EState State { get; private set; }
}