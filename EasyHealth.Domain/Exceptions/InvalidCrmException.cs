namespace EasyHealth.Domain.Exceptions;

public class InvalidCrmException : Exception
{
    private const string _message = "Crm inválido!";

    public InvalidCrmException(string message = _message) : base(message)
    {
    }

    public static void ThrowIfInvalid(int code)
    {
        if (code is > 6 or < 6)
            throw new InvalidCrmException("O código do CRM deve conter 6 digitos!");
    }
}