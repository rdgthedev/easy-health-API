namespace EasyHealth.Domain.Exceptions;

public class UnableToChangeNameException : Exception
{
    private const string _message = "Não foi possível alterar o nome!";

    public UnableToChangeNameException(string message = _message) : base(message)
    {
    }
}