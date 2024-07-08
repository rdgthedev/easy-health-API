namespace EasyHealth.Domain.Exceptions;

public class UnableToChangeTitle : Exception
{
    private const string _message = "Não foi possível alterar o título!";

    public UnableToChangeTitle(string message = _message) : base(message)
    {
    }
}