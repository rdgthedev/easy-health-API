namespace EasyHealth.Domain.Exceptions;

public class UnableToChangeAddress : Exception
{
    private const string _message = "Não foi possível alterar o endereço!";

    public UnableToChangeAddress(string message = _message) : base(message)
    {
    }
}