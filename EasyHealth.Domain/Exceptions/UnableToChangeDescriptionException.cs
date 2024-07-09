namespace EasyHealth.Domain.Exceptions;

public class UnableToChangeDescriptionException : Exception
{
    private const string _message = "Não foi possível alterar a descrição!";

    public UnableToChangeDescriptionException(string message = _message) : base(message)
    {
    }
}