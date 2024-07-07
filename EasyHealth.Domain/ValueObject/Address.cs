using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Exceptions;

namespace EasyHealth.Domain.ValueObject;

public class Address : Shared.ValueObject
{
    public Address(
        string street,
        string neighbordhood,
        int number,
        string city,
        State state,
        string complement = null!)
    {
        Street = street;
        Neighbordhood = neighbordhood;
        Number = number;
        Complement = complement;
        City = city;
        State = state;

        InvalidAddressException.ThrowIfNull(Street, "A rua não pode ser vázia!");
        InvalidAddressException.ThrowIfNull(Neighbordhood, "O bairro não pode ser vázio!");
        InvalidAddressException.ThrowIfLessThan(Number, "O número não deve ser menor ou igual a 0!");
        InvalidAddressException.ThrowIfNull(City, "A cidade não pode ser vázia!");
    }

    public string Street { get; private set; }
    public string Neighbordhood { get; private set; }
    public int Number { get; private set; }
    public string Complement { get; private set; }
    public string City { get; private set; }
    public State State { get; private set; }
}