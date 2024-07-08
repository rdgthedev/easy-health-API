namespace EasyHealth.Domain.Exceptions;

public class UnableToChangeAddressException : Exception
{
    private const string _message = "Não foi possível alterar o endereço!";

    public UnableToChangeAddressException(string message = _message) : base(message)
    {
    }
}