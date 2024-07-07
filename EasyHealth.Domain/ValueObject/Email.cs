namespace EasyHealth.Domain.ValueObject;

public class Email : Shared.ValueObject
{
    public Email(string address) => Address = address;

    public string Address { get; private set; }

    public static implicit operator string(Email email)
        => email.ToString();

    public static implicit operator Email(string email)
        => new(email);

    public override string ToString()
        => Address;
}