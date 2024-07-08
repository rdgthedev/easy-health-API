namespace EasyHealth.Domain.Exceptions;

public class UnableToChangeSectorException : Exception
{
    private const string _message = "Não foi possível alterar o setor!";

    public UnableToChangeSectorException(string message = _message) : base(message)
    {
    }
}