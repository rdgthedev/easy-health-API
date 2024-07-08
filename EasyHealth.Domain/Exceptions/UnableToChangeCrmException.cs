namespace EasyHealth.Domain.Exceptions;

public class UnableToChangeCrmException : Exception
{
    private const string _message = "Não foi possível alterar o CRM!";

    public UnableToChangeCrmException(string message = _message) : base(message)
    {
    }
}