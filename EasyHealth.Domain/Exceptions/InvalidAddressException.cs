namespace EasyHealth.Domain.Exceptions;

public class InvalidAddressException : Exception
{
    private const string _message = "Endereço inválido!";

    public InvalidAddressException(string message = _message) : base(message)
    {
    }

    public static void ThrowIfNull(
        string address,
        string message)
    {
        if (string.IsNullOrEmpty(address.Trim()))
            throw new InvalidAddressException(message);
    }

    public static void ThrowIfLessThan(
        int number,
        string message)
    {
        if (number <= 0)
            throw new InvalidAddressException(message);
    }
}