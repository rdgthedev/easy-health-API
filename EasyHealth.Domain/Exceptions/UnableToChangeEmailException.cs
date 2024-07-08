namespace EasyHealth.Domain.Exceptions;

public class UnableToChangeEmailException : Exception
{
    private const string _message = "Não foi possível alterar o email!";

    public UnableToChangeEmailException(string message = _message) : base(message)
    {
    }
}