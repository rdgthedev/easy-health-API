namespace EasyHealth.Domain.Exceptions;

public class UnableToChangeTitleException : Exception
{
    private const string _message = "Não foi possível alterar o título!";

    public UnableToChangeTitleException(string message = _message) : base(message)
    {
    }
}