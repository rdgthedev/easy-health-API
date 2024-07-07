namespace EasyHealth.Domain.Exceptions;

public class UnableToChangeEmail : Exception
{
    private const string _message = "Não foi possível alterar o email!";

    public UnableToChangeEmail(string message = _message) : base(message)
    {
    }
}